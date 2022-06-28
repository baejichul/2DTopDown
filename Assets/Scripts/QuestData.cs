using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string _questName;
    public int[] _npicId;

    public QuestData(string questName, int[] npicId)
    {
        _questName = questName;
        _npicId = npicId;
    }
}
