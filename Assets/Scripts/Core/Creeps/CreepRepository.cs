using System.Collections.Generic;
using UnityEngine;

public class CreepRepository
{
    private Dictionary<int, CreepModel> _creepModels = new Dictionary<int, CreepModel>();
    
    public GameObject CreepPrefab; //TODO: get from config, have different types of creeps

    public GameObject GetNewCreep()
    {
        //TODO: add new creep model
        return CreepPrefab; //TODO: get new creep from pool
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