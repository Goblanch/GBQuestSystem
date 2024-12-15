using UnityEditor.Experimental.GraphView;

namespace GBQuestSys.Elements
{
    using GBQuestSys.Quest;
    public class QSNode : Node
    {
        public string QuestName {get; set;}
        public GBQuest questData;

        public void Initialize(){
            QuestName = "QuestName";
            questData = new GBQuest();
            questData.Initialize();
        }
    }
}


