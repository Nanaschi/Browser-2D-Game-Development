using UnityEngine;

namespace PlatformerMVC.Interfaces
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}