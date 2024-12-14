using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace GBQuestSys.Windows
{
    public class GBQuestGraphWindow : EditorWindow
    {
        [MenuItem("Window/GBQuestSystem/Quest Graph")]
        public static void Open(){
            GBQuestGraphWindow editorWindow = GetWindow<GBQuestGraphWindow>("QuestEditorWindow");

        }

        private void OnEnable() {
            AddGraphView();
        }

        private void AddGraphView(){
            GBQuestGraphView graphView = new GBQuestGraphView();

            graphView.StretchToParentSize();

            rootVisualElement.Add(graphView);
        }
    }
}


