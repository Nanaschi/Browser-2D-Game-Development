using System;
using UnityEngine;

namespace PlatformerMVC.View
{
    public class QuestObjectView : LevelObjectView
    {
        [SerializeField] private int _id;
        public int Id => _id;

        [SerializeField] private Color _completedColor;
        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
        }

        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }
               
        
        public void ProcessActivated()
        {
            SpriteRenderer.color = _defaultColor;
        }
        
    }
}