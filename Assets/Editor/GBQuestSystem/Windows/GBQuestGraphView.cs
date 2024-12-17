using UnityEditor.Experimental.GraphView;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine;
using GBQuestSys.Elements;
using System.Runtime.Remoting.Messaging;
using GBQuestSys.Utils;

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

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter){
            List<Port> compatiblePorts = new List<Port>();

            ports.ForEach(port => {
                if(startPort == port || startPort.node == port.node || startPort.direction == port.direction) return;
                compatiblePorts.Add(port);
            });

            return compatiblePorts;
        }

        #region MANIPULATORS

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

        #endregion

        #region STYLES

        private void AddGridBackGround(){
            GridBackground gridBackground = new GridBackground();
            gridBackground.StretchToParentSize();
            Insert(0, gridBackground);
        }

        private void AddStyles(){
            this.AddStyleSheets(
                "GBQuestSystem/QuestGraphStyles.uss",
                "GBQuestSystem/GBQuestSysNodeStyles.uss"
            );
        }

        #endregion
    }

}

