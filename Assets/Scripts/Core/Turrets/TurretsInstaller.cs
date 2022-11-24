using Core.Creeps.Entities;
using Core.Turrets.Configs;
using Core.Turrets.Controllers;
using Core.Turrets.Controllers.Projectiles;
using Core.Turrets.Controllers.SpawnTurret;
using Core.Turrets.Entities;
using Core.Turrets.UseCases;
using UnityEngine;

namespace Core.Turrets
{
    public class TurretsInstaller : MonoBehaviour
    {
        [SerializeField] LocalTurretsConfig TurretsLocalConfig;
        [SerializeField] Transform ThumnailTurretsParent;
        [SerializeField] TurretSpawnerPreviewerController SpawnerPreviewerController;

        TurretShootingController _turretShootingController;
        MovingProjectilesController _projectilesMovingController;

        public void Install()
        {
            var serviceLocator = ServiceLocator.ServiceLocator.Instance;
            var turretsRepository = new TurretsRepository(TurretsLocalConfig.TurretsConfig, ThumnailTurretsParent);
            serviceLocator.RegisterService(turretsRepository);

            var projectilesRepository = new ProjectilesRepository(TurretsLocalConfig.TurretsConfig);
            serviceLocator.RegisterService(projectilesRepository);

            var spawnTurretThumbnailsUseCase = new SpawnTurretSelectorUseCase();

            var creepRepository = serviceLocator.GetService<CreepRepository>();
            var updateTurretTargetUseCase = new UpdateTurretTargetUseCase(creepRepository, turretsRepository);
            var updateTurretTargetController = new UpdateTurretTargetController(updateTurretTargetUseCase);

            _turretShootingController = new TurretShootingController(turretsRepository, projectilesRepository);
            _projectilesMovingController = new MovingProjectilesController();

            spawnTurretThumbnailsUseCase.Spawn(turretsRepository, TurretsLocalConfig.TurretsConfig,
                SpawnerPreviewerController);
        }

        private void Update()
        {
            _turretShootingController.Update();
            _projectilesMovingController.Update();
        }
    }
}