using UnityEngine;

namespace PlatformerMVC.Configs
{
    [CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "Configs/ QuestStoryConfig", order = 0)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] QuestConfigs;
        public QuestStoryType QuestStoryType;
    }


    public enum QuestStoryType
    {
        Common, 
        Resettable
    }

}