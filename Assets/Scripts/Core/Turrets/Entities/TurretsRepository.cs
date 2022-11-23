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

        private Dictionary<int, TurretEntity> _turretEntities = new Dictionary<int, TurretEntity>();
        private Dictionary<int, TurretPresenter> _turretPresenters = new Dictionary<int, TurretPresenter>();
        private Dictionary<int, TurretThumbnailPresenter> _turretThumbnailPresenters = new Dictionary<int, TurretThumbnailPresenter>();
        private Dictionary<int, TurretThumbnailController> _turretThumbnailControllers = new Dictionary<int, TurretThumbnailController>();

        private Dictionary<string, GameObjectPool<TurretView>> _pools = new Dictionary<string, GameObjectPool<TurretView>>();

        private Dictionary<string, TurretConfig> _turretsById = new Dictionary<string, TurretConfig>();
        private readonly AssetCatalog.AssetCatalog _assetCatalog;

        public TurretsRepository(TurretsConfig turretsConfig, Transform thumbnailTurretsParent)
        {
            _turretsConfig = turretsConfig;
            _thumbnailTurretsParent = thumbnailTurretsParent;

            _assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();
        
            foreach (var turret in _turretsConfig.Turrets)
            {
                //var prefab = _assetCatalog.LoadResource<TurretView>($"{AssetCatalog.AssetCatalog.Creeps}{turret.PrefabId}");

                //_pools[turret.Id] = new GameObjectPool<TurretView>(prefab, 10);
                _turretsById[turret.Id] = turret;
            }
        }
    
        public TurretEntity SpawnNewTurret(string turretId, Vector3 position)
        {
            var config = _turretsById[turretId];

            var view = GetNewTurretView(turretId);
            var instanceID = view.GetInstanceID();
            _turretPresenters[instanceID] = new TurretPresenter(view);

            _turretEntities[instanceID] = new TurretEntity();

            return _turretEntities[instanceID];
        }

        public void SpawnNewProjectile(string turretId)
        {
            var prefab = _assetCatalog.LoadResource<ProjectileView>(_turretsConfig.ProjectilesConfiguration.RegularProjectile.PrefabPath);
            var view = Object.Instantiate(prefab); //TODO: pool
            var instanceID = view.GetInstanceID();
            new ProjectilePresenter(view);
            new ProjectileController(view);
        }
        
        public void SpawnNewTurretThumbnail(string turretId)
        {
            var config = _turretsById[turretId];
            var prefab = _assetCatalog.LoadResource<TurretThumbnailView>(_turretsConfig.ThumbnailPrefabId);

            var view = Object.Instantiate(prefab, _thumbnailTurretsParent); //TODO: extract from Repository

            var instanceID = view.GetInstanceID();
            _turretThumbnailPresenters[instanceID] = new TurretThumbnailPresenter(view);
            _turretThumbnailControllers[instanceID] = new TurretThumbnailController(this, view, turretId);
        }
    
        public TurretView GetNewTurretView(string turretId) //TODO: move to presenter
        {
            return _pools[turretId].Get();
        }
    }
}