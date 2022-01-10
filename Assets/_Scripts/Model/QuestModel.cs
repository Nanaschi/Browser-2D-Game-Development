using System.Collections;
using System.Collections.Generic;
using PlatformerMVC.Interfaces;
using UnityEngine;

public class QuestModel : IQuestModel
{
    private const string TargetTag = "Player";
    
    
    public bool TryComplete(GameObject activator)
    {
        return activator.CompareTag(TargetTag);
    }
}
