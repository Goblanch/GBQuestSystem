using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GBQuestSys.Elements
{
    using GBQuestSys.Quest;
    using GBQuestSys.Utils;
    using UnityEditor.Search;
    using UnityEngine.UIElements;

    public class QSNode : Node
    {
        public string QuestName {get; set;}
        public GBQuest linkedQuest;

        public void Initialize(){
            QuestName = "QuestName";
            //questData = ScriptableObject.CreateInstance<GBQuest>();
            //questData.Initialize();
        }

        public void Draw(){
            TextField questNameTextField = new TextField(){
                value = QuestName
            };

            titleContainer.Insert(0, questNameTextField);

            AddNodePorts();
            DrawNodeContent();

            RefreshExpandedState();
        }

        private void AddNodePorts(){
            Port inputPort = this.CreatePort("Previous Quest", Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
            inputContainer.Add(inputPort);

            Port outputPort = this.CreatePort("Next Quest", Orientation.Horizontal, Direction.Output, Port.Capacity.Single);
            outputContainer.Add(outputPort);
        }

        protected virtual void DrawNodeContent(){
            ObjectField questField = new ObjectField("Quest"){
                objectType = typeof(GBQuest),
            };
            questField.RegisterValueChangedCallback(evt =>{
                linkedQuest = evt.newValue as GBQuest;
                if(linkedQuest != null){
                    UpdateNodeFromQuest();
                }
            });

            titleContainer.Add(questField);

            Label dialogueLabel = new Label("Dialogues:");
            extensionContainer.Add(dialogueLabel);
        }

        protected virtual void UpdateNodeFromQuest(){
            foreach(var element in extensionContainer.Children()){
                element.RemoveFromHierarchy();
            }

            if(linkedQuest.initialDialogue != null){
                foreach(var dialogue in linkedQuest.initialDialogue){
                    extensionContainer.Add(new Label($"{dialogue.dialogueEmitter}: {dialogue.phrase}"));

                }
            }

            if(linkedQuest.finalDialogue != null){
                foreach(var dialogue in linkedQuest.finalDialogue){
                    extensionContainer.Add(new Label($"{dialogue.dialogueEmitter}: {dialogue.phrase}"));
                    
                }
            }

            RefreshExpandedState();
        }
    }
}


