using System.Collections.Generic;
using Core.Turrets.Configs;
using Core.Turrets.UseCases;
using Core.Turrets.Views;
using Events;
using UnityEngine;

namespace Core.Turrets.Entities
{
    public class ProjectilesRepository
    {
        private readonly ProjectilesConfiguration _projectilesConfiguration;
        private Dictionary<int, ProjectileEntity> _projectileEntities = new Dictionary<int, ProjectileEntity>();
        private Dictionary<string, object> _projectilesById = new Dictionary<string, object>();
        private readonly AssetCatalog.AssetCatalog _assetCatalog;
        private Dictionary<int, IGameElementRepresentation> _projectileGameElementRepresentations = new Dictionary<int, IGameElementRepresentation>();
        private readonly ProjectileFactory _projectileFactory;

        public ProjectilesRepository(TurretsConfig turretsConfig)
        {
            _assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();

            _projectilesConfiguration = turretsConfig.ProjectilesConfiguration;
            _projectileFactory = new ProjectileFactory(_projectilesConfiguration);
            _projectilesById[_projectilesConfiguration.FrozenProjectile.Id] = _projectilesConfiguration.FrozenProjectile;
            _projectilesById[_projectilesConfiguration.RegularProjectile.Id] = _projectilesConfiguration.RegularProjectile;
        }

        public ProjectileEntity SpawnNewProjectile(TurretEntity turretEntity)
        {
            var config = (ProjectileConfiguration)_projectilesById[turretEntity.ProjectileId];

            var projectileRepresentation = _projectileFactory.Get(config);

            var view = projectileRepresentation.GameView as ProjectileView;
            var instanceID = view.GetInstanceID();

            _projectileEntities[instanceID] = new ProjectileEntity
            {
                Id = config.Id,
                InstanceId = instanceID,
                Damage = config.Damage,
                Speed = config.Speed,
                Position = turretEntity.Position,
                TargetPosition = turretEntity.Target.CurrentPosition
            };
            
            _projectileGameElementRepresentations[instanceID] = projectileRepresentation;
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
        
        public void DestroyProjectile(int instanceID)
        {
            PoolService.StoreGameRepresentationObject<ProjectileRegularGameElementRepresentation>(_projectileGameElementRepresentations[instanceID]);
        }

        public ProjectileEntity GetProjectileEntity(int instanceId)
        {
            return _projectileEntities[instanceId];
        }
    }
}