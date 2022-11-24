using System.Collections.Generic;
using Core.Creeps.Configs;
using Core.Creeps.Views;
using Pool;
using Pool.BaseObjectRepresentation;
using UnityEngine;

namespace Core.Creeps.Entities
{
    public class CreepRepository
    {
        private readonly CreepsConfig _creepsConfig;

        private Dictionary<int, CreepEntity> _creepEntities = new Dictionary<int, CreepEntity>();
        private Dictionary<int, CreepGameElementRepresentation> _creepGameElementRepresentations = new Dictionary<int, CreepGameElementRepresentation>();

        private Dictionary<string, CreepConfig> _creepsById = new Dictionary<string, CreepConfig>();

        public CreepRepository(CreepsConfig creepsConfig)
        {
            _creepsConfig = creepsConfig;

            foreach (var creep in _creepsConfig.Creeps)
            {
                _creepsById[creep.Id] = creep;
            }
        }
    
        public CreepEntity SpawnNewCreep(string creepId, Vector3 position)
        {
            var config = _creepsById[creepId];
            var assetCatalog = ServiceLocator.ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();
            var prefab = assetCatalog.LoadResource<CreepView>(config.PrefabId);
            var creepGameRepresentation = GameRepresentationObjectFactory.GameRepresentationObject<CreepGameElementRepresentation>(prefab);
        
            var view = creepGameRepresentation.GameView as CreepView;
            var instanceID = view.GetInstanceID();
        
            _creepEntities[instanceID] = new CreepEntity //TODO: add to CreepGameRepresentation
            {
                CurrentPosition = position,
                Health = config.Health,
                Reward = config.Reward,
                Id = config.Id,
                InstanceId = instanceID,
                CurrentSpeed = config.Speed
            };

            _creepGameElementRepresentations[instanceID] = creepGameRepresentation;

            return _creepEntities[instanceID];
        }

        public void DestroyCreep(int instanceID)
        {
            PoolService.StoreGameRepresentationObject<CreepGameElementRepresentation>(_creepGameElementRepresentations[instanceID]);
        }
    
        public CreepEntity GetCreepEntity(int instanceID) 
        {
            return _creepEntities[instanceID];
        }

        public CreepConfig GetCreepConfig(string creepId)
        {
            return _creepsById[creepId];
        }
    }
}