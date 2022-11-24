using System.Collections.Generic;
using Core.Turrets.Configs;
using Core.Turrets.Views;
using Events;
using UnityEngine;

namespace Core.Turrets.Entities
{
    public class ProjectilesRepository
    {
        private readonly ProjectilesConfiguration _projectilesConfiguration;
        private Dictionary<int, ProjectilePresenter> _projectilePresenters = new Dictionary<int, ProjectilePresenter>();
        private Dictionary<int, ProjectileEntity> _projectileEntities = new Dictionary<int, ProjectileEntity>();
        private Dictionary<int, ProjectileController> _projectileControllers = new Dictionary<int, ProjectileController>();
        private Dictionary<string, object> _projectilesById = new Dictionary<string, object>();
        private readonly AssetCatalog.AssetCatalog _assetCatalog;

        public ProjectilesRepository(TurretsConfig turretsConfig)
        {
            _assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();

            _projectilesConfiguration = turretsConfig.ProjectilesConfiguration;
            
            _projectilesById[_projectilesConfiguration.FrozenProjectile.Id] = _projectilesConfiguration.FrozenProjectile;
            _projectilesById[_projectilesConfiguration.RegularProjectile.Id] = _projectilesConfiguration.RegularProjectile;
        }

        public ProjectileEntity SpawnNewProjectile(TurretEntity turretEntity) //TODO: move to new repo
        {
            var config = (ProjectileConfiguration)_projectilesById[turretEntity.ProjectileId];

            var prefab = _assetCatalog.LoadResource<ProjectileView>(_projectilesConfiguration.RegularProjectile.PrefabPath);
            var creepGameRepresentation = GameRepresentationObjectFactory.GameRepresentationObject<ProjectileGameRepresentation>(prefab);

            var view = creepGameRepresentation.GameView as ProjectileView;
            var instanceID = view.GetInstanceID();

            _projectilePresenters[instanceID] = new ProjectilePresenter(view);
            _projectileEntities[instanceID] = new ProjectileEntity
            {
                Id = config.Id,
                InstanceId = instanceID,
                Damage = config.Damage,
                Speed = config.Speed,
                Position = turretEntity.Position,
                TargetPosition = turretEntity.Target.CurrentPosition
            };
            _projectileControllers[instanceID] = new ProjectileController(view);

            return _projectileEntities[instanceID];
        }
        
        public T GetProjectileConfig<T>(int instanceId)
        {
            var entity = _projectileEntities[instanceId];
            return GetProjectileConfig<T>(entity.Id);
        }
        
        public T GetProjectileConfig<T>(string projectileId)
        {
            return (T)_projectilesById[projectileId];
        }
    }
}