using UnityEngine;
using System.Collections.Generic;

namespace GBQuestSys.Data{
    public enum Characters{
        Player,
        NPC
    }

    [System.Serializable]
    public class Dialogue{
        public string phrase;
        public Characters dialogueEmitter;
    }
}

