using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEditor;

namespace GBQuestSys.Elements
{
    using System.Collections.Generic;
    using GBQuestSys.Data;
    using GBQuestSys.Quest;
    using UnityEditor.Search;
    using UnityEngine.UIElements;

    public class QSEditableNode : QSNode
    {
        private ListView initialDialogueListView = new ListView();
        private ListView finalDialogueListView = new ListView();

        private List<Dialogue> initialDialogues = new List<Dialogue>();
        private List<Dialogue> finalDialogues = new List<Dialogue>();

        protected override void DrawNodeContent()
        {
            ObjectField questField = new ObjectField("Linked Quest")
            {
                objectType = typeof(GBQuest)
            };
            questField.RegisterValueChangedCallback(evt =>
            {
                linkedQuest = evt.newValue as GBQuest;
                if (linkedQuest != null)
                {
                    LoadQuestData();
                }
            });

            mainContainer.Add(questField);

            AddDialogueSection("Initial Dialogue", initialDialogues, initialDialogueListView);
            AddDialogueSection("Final Dialogue", finalDialogues, finalDialogueListView);


            Button saveButton = new Button(SaveQuestToScriptableObject) { text = "Save Quest" };
            mainContainer.Add(saveButton);
 
        }

        private void AddDialogueSection(string sectionTitle, List<Dialogue> dialogues, ListView listView)
        {
            Label label = new Label(sectionTitle) { style = { unityFontStyleAndWeight = FontStyle.Bold } };
            extensionContainer.Add(label);

            listView = new ListView
            {
                itemsSource = dialogues,
                fixedItemHeight = 30,
                makeItem = () => CreateDialogueRow(),
                bindItem = (element, i) => BindDialogueRow(element, dialogues[i]),
                selectionType = SelectionType.None,
                reorderable = false
            };

            Button addButton = new Button(() =>
            {
                dialogues.Add(new Dialogue { phrase = "", dialogueEmitter = Characters.Player });
                listView.Rebuild();
            })
            { text = "Add Dialogue" };

            extensionContainer.Add(listView);
            extensionContainer.Add(addButton);
        }

        private VisualElement CreateDialogueRow()
        {
            VisualElement row = new VisualElement { style = { flexDirection = FlexDirection.Row } };

            TextField textField = new TextField { style = { flexGrow = 1 } };
            EnumField characterDropdown = new EnumField(Characters.Player);

            row.Add(textField);
            row.Add(characterDropdown);

            return row;
        }

        private void BindDialogueRow(VisualElement element, Dialogue dialogue)
        {
            TextField textField = (TextField)element[0];
            EnumField characterDropdown = (EnumField)element[1];

            textField.value = dialogue.phrase;
            textField.RegisterValueChangedCallback(evt => dialogue.phrase = evt.newValue);

            characterDropdown.value = dialogue.dialogueEmitter;
            characterDropdown.RegisterValueChangedCallback(evt => dialogue.dialogueEmitter = (Characters)evt.newValue);
        }

        private void SaveQuestToScriptableObject()
        {
            if (linkedQuest == null)
            {
                // Crear un nuevo ScriptableObject
                string path = EditorUtility.SaveFilePanelInProject("Save Quest", "NewQuest", "asset", "Select location to save quest");
                if (!string.IsNullOrEmpty(path))
                {
                    GBQuest newQuest = ScriptableObject.CreateInstance<GBQuest>();
                    newQuest.initialDialogue = new List<Dialogue>(initialDialogues);
                    newQuest.finalDialogue = new List<Dialogue>(finalDialogues);
                    AssetDatabase.CreateAsset(newQuest, path);
                    AssetDatabase.SaveAssets();

                    linkedQuest = newQuest;
                }
            }
            else
            {
                // Actualizar el ScriptableObject existente
                linkedQuest.initialDialogue = new List<Dialogue>(initialDialogues);
                linkedQuest.finalDialogue = new List<Dialogue>(finalDialogues);
                EditorUtility.SetDirty(linkedQuest);
                AssetDatabase.SaveAssets();
            }

            // Actualizar el ObjectField
            mainContainer.Q<ObjectField>().value = linkedQuest;
        }

        private void LoadQuestData()
        {
            initialDialogues.Clear();
            finalDialogues.Clear();

            if (linkedQuest != null)
            {
                initialDialogues.AddRange(linkedQuest.initialDialogue);
                finalDialogues.AddRange(linkedQuest.finalDialogue);
            }

            initialDialogueListView.Rebuild();
            finalDialogueListView.Rebuild();
        }
    }

}