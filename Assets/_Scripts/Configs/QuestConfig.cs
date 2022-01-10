using UnityEngine;

namespace PlatformerMVC.Configs
{
    [CreateAssetMenu(fileName = "QuestConfig", menuName = "Configs/ QuestConfig", order = 0)]
    public class QuestConfig : ScriptableObject
    {
        public int id;

        public QuestType QuestType;
    }
    
    
    public enum QuestType
    {
        Coins
    }
}