using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace GBQuestSys.Windows
{
    public class GBQuestGraphView : GraphView
    {
        public GBQuestGraphView(){
            AddGridBackGround();
        }

        private void AddGridBackGround(){
            GridBackground gridBackground = new GridBackground();

            gridBackground.StretchToParentSize();

            Insert(0, gridBackground);
        }
    }

}

