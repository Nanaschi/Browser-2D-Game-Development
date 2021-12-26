using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerAnimatorConfig;
        [SerializeField] private int _animationSpeed;
        [SerializeField] private LevelObjectView _playerView;

        private SpriteAnimatorController _playerAnimator;

        private void Start()
        {
            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimatorConfig");
            if (_playerAnimatorConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimStatePlayer.Run, true, _animationSpeed);
            }
            
        }

        private void Update()
        {
            _playerAnimator.Update();
        }
    }
}

