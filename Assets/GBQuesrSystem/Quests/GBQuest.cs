using UnityEngine;

namespace GBQuestSys.Quest
{
    using System.Collections.Generic;
    using GBQuestSys.Data;

    [CreateAssetMenu(fileName = "NewQuest", menuName = "GBQuestSystem/Quests/GBQuest")]
    public class GBQuest : ScriptableObject
    {
        public List<Dialogue> initiaDialogue;
        public List<Dialogue> finalDialogue;

        public void Initialize(){
            initiaDialogue = new List<Dialogue>();
            finalDialogue = new List<Dialogue>();
        }
    }

}


