using System.Collections.Generic;
using Core.Turrets.Configs;
using Core.Turrets.Views;
using Events;
using UnityEngine;

namespace Core.Turrets.Entities
{
    public class TurretsRepository
    {
        private readonly TurretsConfig _turretsConfig;
        private readonly Transform _thumbnailTurretsParent;
        private readonly ProjectilesConfiguration _projectilesConfiguration;

        private Dictionary<int, TurretEntity> _turretEntities = new Dictionary<int, TurretEntity>();
        private Dictionary<int, TurretPresenter> _turretPresenters = new Dictionary<int, TurretPresenter>();
        
        private Dictionary<int, TurretThumbnailPresenter> _turretThumbnailPresenters = new Dictionary<int, TurretThumbnailPresenter>();
        private Dictionary<int, TurretThumbnailController> _turretThumbnailControllers = new Dictionary<int, TurretThumbnailController>();
        
        private Dictionary<int, ProjectilePresenter> _projectilePresenters = new Dictionary<int, ProjectilePresenter>();
        private Dictionary<int, ProjectileEntity> _projectileEntities = new Dictionary<int, ProjectileEntity>();
        private Dictionary<int, ProjectileController> _projectileControllers = new Dictionary<int, ProjectileController>();

        private Dictionary<string, GameObjectPool<TurretView>> _pools = new Dictionary<string, GameObjectPool<TurretView>>();

        private Dictionary<string, TurretConfig> _turretsById = new Dictionary<string, TurretConfig>();

        private Dictionary<string, object> _projectilesById = new Dictionary<string, object>();

        private readonly AssetCatalog.AssetCatalog _assetCatalog;

        public TurretsRepository(TurretsConfig turretsConfig, Transform thumbnailTurretsParent)
        {
            _turretsConfig = turretsConfig;
            _thumbnailTurretsParent = thumbnailTurretsParent;
            _projectilesConfiguration = turretsConfig.ProjectilesConfiguration;

            _assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();
        
            foreach (var turret in _turretsConfig.Turrets)
            {
                //var prefab = _assetCatalog.LoadResource<TurretView>($"{AssetCatalog.AssetCatalog.Creeps}{turret.PrefabId}");

                //_pools[turret.Id] = new GameObjectPool<TurretView>(prefab, 10);
                _turretsById[turret.Id] = turret;
            }

            _projectilesById[_projectilesConfiguration.FrozenProjectile.Id] = _projectilesConfiguration.FrozenProjectile;
            _projectilesById[_projectilesConfiguration.RegularProjectile.Id] = _projectilesConfiguration.RegularProjectile;
        }
    
        public TurretEntity SpawnNewTurret(string turretId, Vector3 position)
        {
            var config = _turretsById[turretId];

            //var view = GetNewTurretView(turretId);
            
            var prefab = _assetCatalog.LoadResource<TurretView>(config.PrefabId); //TODO: pool
            var view = Object.Instantiate(prefab);
            var instanceID = view.GetInstanceID();
            _turretPresenters[instanceID] = new TurretPresenter(view, position);

            _turretEntities[instanceID] = new TurretEntity
            {
                TurretShootCooldown = config.Cooldown,
                Position = position,
                ProjectileId = config.ProjectileId,
                Target = null,
                TimeSinceLastShot = 0,
            };

            return _turretEntities[instanceID];
        }
        
        public ProjectileEntity SpawnNewProjectile(TurretEntity turretEntity) //TODO: move to new repo
        {
            var config = (ProjectileConfiguration)_projectilesById[turretEntity.ProjectileId];

            //TODO: projectileFactory:
            var prefab = _assetCatalog.LoadResource<ProjectileView>(_projectilesConfiguration.RegularProjectile.PrefabPath); //TODO: pool
            var view = Object.Instantiate(prefab);
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

        public void SpawnNewTurretThumbnail(string turretId, TurretSpawnerPreviewerController controller) //TODO: remove controller, move to group
        {
            var config = _turretsById[turretId];
            var prefab = _assetCatalog.LoadResource<TurretThumbnailView>(_turretsConfig.ThumbnailPrefabId);

            var view = Object.Instantiate(prefab, _thumbnailTurretsParent); //TODO: extract from Repository

            var instanceID = view.GetInstanceID();
            _turretThumbnailPresenters[instanceID] = new TurretThumbnailPresenter(view);
            _turretThumbnailControllers[instanceID] = new TurretThumbnailController(this, view, turretId, controller);
        }
    
        public TurretView GetNewTurretView(string turretId) //TODO: move to presenter
        {
            return _pools[turretId].Get();
        }

        public TurretEntity GetTurretEntity(int turretInstanceId)
        {
            return _turretEntities[turretInstanceId];
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