using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using Codice.CM.SEIDInfo;

namespace GBQuestSys.Utils
{
    public static class NodeElementsFactory
    {
        public static Port CreatePort(this Node node, string portName, Orientation orientation = Orientation.Horizontal, Direction direction = Direction.Output, Port.Capacity capacity = Port.Capacity.Single){
            Port newPort = node.InstantiatePort(orientation, direction, capacity, typeof(bool));
            newPort.portName = portName;

            return newPort;
        }
    }
}


