using System.Collections.Generic;
using Core.AssetCatalog;
using Events;
using UnityEngine;

public class CreepRepository
{
    private readonly CreepsConfig _creepsConfig;

    private Dictionary<int, CreepEntity> _creepEntities = new Dictionary<int, CreepEntity>();
    private Dictionary<int, CreepPresenter> _creepPresenters = new Dictionary<int, CreepPresenter>();

    private Dictionary<string, GameObjectPool<CreepView>> _pools = new Dictionary<string, GameObjectPool<CreepView>>();

    private Dictionary<string, CreepConfig> _creepsById = new Dictionary<string, CreepConfig>();

    public CreepRepository(CreepsConfig creepsConfig)
    {
        _creepsConfig = creepsConfig;

        var assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog>();
        
        foreach (var creep in _creepsConfig.Creeps)
        {
            var prefab = assetCatalog.LoadResource<CreepView>($"{AssetCatalog.Creeps}{creep.PrefabId}");

            _pools[creep.Id] = new GameObjectPool<CreepView>(prefab, 10);
            _creepsById[creep.Id] = creep;
        }
    }
    
    public CreepEntity SpawnNewCreep(string creepId, Vector3 position)
    {
        var config = _creepsById[creepId];

        var view = GetNewCreepView(creepId);
        var instanceID = view.GetInstanceID();
        _creepPresenters[instanceID] = new CreepPresenter(view);
        
        _creepEntities[instanceID] = new CreepEntity
        {
            CurrentPosition = position,
            Health = config.Health,
            Id = config.Id,
            InstanceId = instanceID,
            CurrentSpeed = config.Speed
        };

        return _creepEntities[instanceID];
    }
    
    public CreepEntity GetCreepEntity(int instanceID) 
    {
        return _creepEntities[instanceID];
    }

    
    public CreepView GetNewCreepView(string creepId) //TODO: move to presenter
    {
        return _pools[creepId].Get();
    }
    
    public CreepConfig GetCreepConfig(string creepId)
    {
        return _creepsById[creepId];
    }

    public void RemoveCreep(int id)
    {
        //TODO: call when creep died or whatever
        _creepEntities.Remove(id);
    }

    public void UpdateCreepState(float health, int creepId)
    {
        _creepEntities[creepId].Health = health;
    }
}