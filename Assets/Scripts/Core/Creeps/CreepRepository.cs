using System.Collections.Generic;
using UnityEngine;

public class CreepRepository
{
    private readonly CreepsConfig _creepsConfig;

    //TODO: create creep factory
    private Dictionary<int, CreepModel> _creepModels = new Dictionary<int, CreepModel>();

    private Dictionary<string, GameObjectPool<CreepView>> _pools = new Dictionary<string, GameObjectPool<CreepView>>();

    public CreepRepository(CreepsConfig creepsConfig)
    {
        _creepsConfig = creepsConfig;

        foreach (var creep in _creepsConfig.Creeps)
        {
            _pools[creep.Id] = new GameObjectPool<CreepView>(creep.Prefab, 10);
        }
    }
    public CreepView GetNewCreep(string creepId)
    {
        return _pools[creepId].Get();
    }

    public void RemoveCreep(int id)
    {
        //TODO: call when creep died or whatever
        _creepModels.Remove(id);
    }

    public void UpdateCreepState(float health, int creepId)
    {
        _creepModels[creepId].Health = health;
    }
}