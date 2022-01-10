using System.Collections;
using System.Collections.Generic;
using PlatformerMVC.Controllers;
using PlatformerMVC.View;
using UnityEngine;

public class QuestConfiguratorController
{
    private QuestObjectView _singleQuestView;
    private QuestController _singleQuest;

    public QuestConfiguratorController(QuestView singleQuestView)
    {
        _singleQuestView = singleQuestView._SingleQuestObjectView;
    }


    public void Initialization()
    {
        _singleQuest = new QuestController(_singleQuestView, new QuestModel());
        _singleQuest.Reset();
    }
}
