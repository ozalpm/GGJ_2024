using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CubeEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Scripts", order = 1)]
public class NpcSC : ScriptableObject
{
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
        }
    }
}
