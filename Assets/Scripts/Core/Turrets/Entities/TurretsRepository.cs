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

        private Dictionary<int, TurretEntity> _turretEntities = new Dictionary<int, TurretEntity>();
        private Dictionary<int, TurretPresenter> _turretPresenters = new Dictionary<int, TurretPresenter>();

        private Dictionary<string, GameObjectPool<TurretView>> _pools = new Dictionary<string, GameObjectPool<TurretView>>();

        private Dictionary<string, TurretConfig> _turretsById = new Dictionary<string, TurretConfig>();

        public TurretsRepository(TurretsConfig turretsConfig)
        {
            _turretsConfig = turretsConfig;

            var assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();
        
            foreach (var turret in _turretsConfig.Turrets)
            {
                var prefab = assetCatalog.LoadResource<TurretView>($"{AssetCatalog.AssetCatalog.Creeps}{turret.PrefabId}");

                _pools[turret.Id] = new GameObjectPool<TurretView>(prefab, 10);
                _turretsById[turret.Id] = turret;
            }
        }
    
        public TurretEntity SpawnNewTurret(string creepId, Vector3 position)
        {
            var config = _turretsById[creepId];

            var view = GetNewTurretView(creepId);
            var instanceID = view.GetInstanceID();
            _turretPresenters[instanceID] = new TurretPresenter(view);
        
            _turretEntities[instanceID] = new TurretEntity()
            {
            };

            return _turretEntities[instanceID];
        }
    
        public TurretView GetNewTurretView(string turretId) //TODO: move to presenter
        {
            return _pools[turretId].Get();
        }
    }
}