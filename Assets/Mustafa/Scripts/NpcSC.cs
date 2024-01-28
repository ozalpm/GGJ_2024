using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CubeEngine;

[CreateAssetMenu(fileName = "Npc", menuName = "ScriptableObjects/Npc")]
public class NpcSC : ScriptableObject
{
    public string npcName;
    public AudioClip[] reactionClips;
    public QuestionsGroup[] questionsGroups;
    [Serializable]
    public class QuestionsGroup
    {
        public Questions[] questions;
        [Serializable]
        public class Questions
        {
            public string questionString;
            public QuestionsReaction questionsReaction;
            public AudioClip clip;
        }
    }
}
