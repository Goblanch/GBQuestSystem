using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor;
using Unity.VisualScripting;

namespace GBQuestSys.Windows
{
    public class GBQuestGraphView : GraphView
    {
        public GBQuestGraphView(){
            AddManipulators();
            AddGridBackGround();
            AddStyles();
        }

        private void AddManipulators(){
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());   
        }

        private void AddGridBackGround(){
            GridBackground gridBackground = new GridBackground();
            gridBackground.StretchToParentSize();
            Insert(0, gridBackground);
        }

        private void AddStyles(){
            StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("GBQuestSystem/QuestGraphStyles.uss");
            styleSheets.Add(styleSheet);
        }
    }

}

