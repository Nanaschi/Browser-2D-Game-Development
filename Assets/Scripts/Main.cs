using System;
using System.Collections;
using System.Collections.Generic;
using PlatformerMVC.Configs;
using PlatformerMVC.Controllers;
using PlatformerMVC.View;
using UnityEngine;


namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerAnimatorConfig;
        [SerializeField] private int _animationSpeed;
        [SerializeField] private LevelObjectView _playerView;

        private SpriteAnimatorController _playerAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;

        private void Start()
        {
            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimatorConfig");
            if (_playerAnimatorConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            }

            _cameraController = new CameraController(_playerView.PlayerTransform, Camera.main.transform);
            _playerController = new PlayerController(_playerView, _playerAnimator);

        }

        private void Update()
        {
            _playerController.Update();
            _cameraController.Update();
        }
    }
}

