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
            AddStyles();
        }

        private void AddGraphView(){
            GBQuestGraphView graphView = new GBQuestGraphView();
            graphView.StretchToParentSize();
            rootVisualElement.Add(graphView);
        }

        private void AddStyles(){
            StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("GBQuestSystem/GBQuestSysVariables.uss");
            rootVisualElement.styleSheets.Add(styleSheet);
        }
    }
}


