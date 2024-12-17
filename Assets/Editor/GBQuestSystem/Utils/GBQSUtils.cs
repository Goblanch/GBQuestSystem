using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using Codice.CM.SEIDInfo;
using Unity.VisualScripting;
using UnityEditor;

namespace GBQuestSys.Utils
{
    public static class GBQSUtils
    {
        #region PORTS

        public static Port CreatePort(this Node node, string portName, Orientation orientation = Orientation.Horizontal, Direction direction = Direction.Output, Port.Capacity capacity = Port.Capacity.Single){
            Port newPort = node.InstantiatePort(orientation, direction, capacity, typeof(bool));
            newPort.portName = portName;

            return newPort;
        }

        #endregion

        #region STYLES

        public static VisualElement AddStyleSheets(this VisualElement element, params string[] styleSheets){
            foreach(string  styleSheetName in styleSheets){
                StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load(styleSheetName);
                element.styleSheets.Add(styleSheet);
            }

            return element;
        }

        public static VisualElement AddStyleClasses(this VisualElement element, params string[] classNames){
            foreach(string className in classNames){
                element.AddToClassList(className);
            }

            return element;
        }

        #endregion
    }
}


