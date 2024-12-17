using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine;
using GBQuestSys.Elements;

namespace GBQuestSys.Windows
{
    public class GBQuestGraphView : GraphView
    {
        public GBQuestGraphView(){
            AddManipulators();
            AddGridBackGround();
            AddStyles();
        }

        private QSNode CreateNode(Vector2 position){
            QSNode node = new QSNode();
            node.Initialize(position);
            node.Draw();
            return node;
        }

        private void AddManipulators(){
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());   
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            this.AddManipulator(CreateNodeContextMenu());
        }

        private IManipulator CreateNodeContextMenu(){
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction("Add Node", actionEvent => AddElement(CreateNode(actionEvent.eventInfo.localMousePosition)))
            );

            return contextualMenuManipulator;
        }

        private void AddGridBackGround(){
            GridBackground gridBackground = new GridBackground();
            gridBackground.StretchToParentSize();
            Insert(0, gridBackground);
        }

        private void AddStyles(){
            StyleSheet graphStyleSheet = (StyleSheet) EditorGUIUtility.Load("GBQuestSystem/QuestGraphStyles.uss");
            StyleSheet nodeStyleSheet = (StyleSheet) EditorGUIUtility.Load("GBQuestSystem/GBQuestSysNodeStyles.uss");
            styleSheets.Add(graphStyleSheet);
            styleSheets.Add(nodeStyleSheet);
        }
    }

}

