using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC.Configs
{
    [CreateAssetMenu(fileName = "QuestItemConfig", menuName = "Configs/ QuestItemConfig", order = 0)]
    public class QuestItemConfig : ScriptableObject
    {
        public int QuestID;
        public List<int> QuestItemCollection;
    }
}