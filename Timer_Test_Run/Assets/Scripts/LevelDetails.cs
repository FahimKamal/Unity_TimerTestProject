using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/LevelDetails", fileName = "LevelDetails")]
public class LevelDetails : ScriptableObject
{
    public List<LevelDetail> levelDetailList;
}

[Serializable]
public class LevelDetail
{
    public int level;
    public int timeLimit;
}
