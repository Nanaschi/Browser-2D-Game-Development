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

        #region Views
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CanonView _canonView;
        #endregion



        #region Controllers
        private SpriteAnimatorController _playerAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;
        private CanonAimController _canonAimController;
        private BulletEmitterController _bulletEmitterController; //The intialization of BulletController we make here
        #endregion

        
        private void Start()
        {
            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimatorConfig");
            if (_playerAnimatorConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            }

            _cameraController = new CameraController(_playerView._Transform, Camera.main.transform);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            _canonAimController = new CanonAimController(_canonView._muzzleTransform, _playerView._Transform);
            _bulletEmitterController = new BulletEmitterController(_canonView._bullets, _canonView._emitterTransform);
        }

        private void LateUpdate()
        {
            _playerController.Update();
            _cameraController.Update();
            _canonAimController.Update();
            _bulletEmitterController.Update();
        }
    }
}

