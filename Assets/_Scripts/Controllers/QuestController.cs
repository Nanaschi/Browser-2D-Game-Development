using System;
using PlatformerMVC.Interfaces;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class QuestController : IQuest
    {



        public event EventHandler<IQuest> Completed;
        public bool IsComppleted { get; private set; }

        private QuestObjectView _questObjectView;
        private bool _active;
        private IQuestModel _questModel;

        public QuestController(QuestObjectView questObjectView, IQuestModel questModel)
        {
            _questObjectView = questObjectView;
            _questModel = questModel;
        }

        private void OnContact(LevelObjectView arg)
        {
            bool completed = _questModel.TryComplete(arg.gameObject);
            if (completed) Complete();
        }

        private void Complete()
        {
            if(!_active) return;
            _active = false;
            _questObjectView.OnObjectContact -= OnContact;
            _questObjectView.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }
        public void Reset()
        {
            if (_active) return;
            _active = true;
            _questObjectView.OnObjectContact += OnContact;
            _questObjectView.ProcessActivated();
        }
        
        public void Dispose()
        {
            _questObjectView.OnObjectContact -= OnContact;
        }
    }
}