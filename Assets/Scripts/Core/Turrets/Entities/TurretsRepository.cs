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
        
       
        private Dictionary<string, TurretConfig> _turretsById = new Dictionary<string, TurretConfig>();


        private readonly AssetCatalog.AssetCatalog _assetCatalog;

        public TurretsRepository(TurretsConfig turretsConfig, Transform thumbnailTurretsParent)
        {
            _turretsConfig = turretsConfig;
            _thumbnailTurretsParent = thumbnailTurretsParent;

            _assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();
        
            foreach (var turret in _turretsConfig.Turrets)
            {
                _turretsById[turret.Id] = turret;
            }

           
        }
    
        public TurretEntity SpawnNewTurret(string turretId, Vector3 position)
        {
            var config = _turretsById[turretId];
            var prefab = _assetCatalog.LoadResource<TurretView>(config.PrefabId); //TODO: pool

            var turretGameRepresentation = GameRepresentationObjectFactory.GameRepresentationObject<TurretGameRepresentation>(prefab);
            turretGameRepresentation.SetInitialPosition(position);
            
            var view = turretGameRepresentation.GameView as TurretView;
            var instanceID = view.GetInstanceID();

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
        
        

        public void SpawnNewTurretThumbnail(string turretId, TurretSpawnerPreviewerController controller) //TODO: remove controller, move to group
        {
            var config = _turretsById[turretId];
            var prefab = _assetCatalog.LoadResource<TurretThumbnailView>(_turretsConfig.ThumbnailPrefabId);

            var view = Object.Instantiate(prefab, _thumbnailTurretsParent); //TODO: extract from Repository

            var instanceID = view.GetInstanceID();
            _turretThumbnailPresenters[instanceID] = new TurretThumbnailPresenter(view);
            _turretThumbnailControllers[instanceID] = new TurretThumbnailController(this, view, turretId, controller);
        }

        public TurretEntity GetTurretEntity(int turretInstanceId)
        {
            return _turretEntities[turretInstanceId];
        }

        
    }
}