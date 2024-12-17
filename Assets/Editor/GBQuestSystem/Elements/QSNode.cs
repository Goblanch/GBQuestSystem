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

        public void Initialize(Vector2 position){
            QuestName = "QuestName";
            
            SetPosition(new Rect(position, Vector2.zero));

            AddNodeStyles();
        }

        private void AddNodeStyles(){
            titleContainer.AddToClassList("ds-node__title-container");
            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
            inputContainer.AddToClassList("ds-node__input-container");
            outputContainer.AddToClassList("ds-node__output-container");
        }

        public void Draw(){
            TextField questNameTextField = new TextField(){
                value = QuestName
            };

            questNameTextField.AddToClassList("ds-node__textfield");  

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
            mainContainer.Add(questField);
        }

    }
}


