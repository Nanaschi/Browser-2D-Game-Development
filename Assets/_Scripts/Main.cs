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

        [SerializeField] private List<CoinView> _coinViews;
        #region Configs
        private SpriteAnimatorConfig _playerAnimatorConfig;
        private SpriteAnimatorConfig _coinAnimatorConfig;
        

        #endregion


        #region Views
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CanonView _canonView;
        [SerializeField] private LevelGeneratorView _levelGeneratorView;
        [SerializeField] private QuestView _questView;//NEW LESSON 7
        #endregion



        #region Controllers
        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;
        private CanonAimController _canonAimController;
        private BulletEmitterController _bulletEmitterController; 
        private CoinsController _coinsController;
        private GeneratorController _levelGeneratorController;
        private QuestConfiguratorController _questConfiguratorController;//NEW LESSON 7
        #endregion

        
        private void Start()
        {
            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimatorConfig");
            if (_playerAnimatorConfig) _playerAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            
            _coinAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimConfiguration");
            if (_coinAnimatorConfig) _coinAnimator = new SpriteAnimatorController(_coinAnimatorConfig);
            
           
            

            _cameraController = new CameraController(_playerView._Transform, Camera.main.transform);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            _canonAimController = new CanonAimController(_canonView._muzzleTransform, _playerView._Transform);
            _bulletEmitterController = new BulletEmitterController(_canonView._bullets, _canonView._emitterTransform);
            
            
            _coinsController = new CoinsController(_playerView, _coinAnimator, _coinViews);

            _levelGeneratorController = new GeneratorController(_levelGeneratorView);
            _levelGeneratorController.Initialize();

            _questConfiguratorController = new QuestConfiguratorController(_questView); //NEW LESSON 7
            _questConfiguratorController.Initialization(); //NEW LESSON 7
        }

        private void LateUpdate()
        {
            _playerController.Update();
            _cameraController.Update();
            _canonAimController.Update();
            _bulletEmitterController.Update();
            _coinAnimator.Update();
        }
    }
}

