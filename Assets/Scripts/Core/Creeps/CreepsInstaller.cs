using Core.Creeps.Configs;
using Core.Creeps.Controllers;
using Core.Creeps.Entities;
using Core.Creeps.UseCase;
using Core.SpawnerPoints.Configs;
using Core.SpawnerPoints.Entities;
using UnityEngine;

namespace Core.Creeps
{
    public class CreepsInstaller : MonoBehaviour
    {
        [SerializeField] LocalCreepsConfig CreepsLocalConfig;
        [SerializeField] LevelSpawnerPointsLocalConfig SpawnerPointsConfig;
        [SerializeField] Transform UserBasePosition;
        
        private MovingCreepsController _movingCreepsController;

        public void Install()
        {
            var serviceLocator = ServiceLocator.ServiceLocator.Instance;
        
            var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
            serviceLocator.RegisterService(creepRepository);
        
            var spawnerPointsRepository = new SpawnerPointsRepository(SpawnerPointsConfig.Spawners);
            serviceLocator.RegisterService(spawnerPointsRepository);
        
            var moveCreepsUseCase = new MoveCreepsUseCase(creepRepository, UserBasePosition);
            _movingCreepsController = new MovingCreepsController(moveCreepsUseCase);
        }

        private void Update()
        {
            _movingCreepsController.Update();
        }
    }
}