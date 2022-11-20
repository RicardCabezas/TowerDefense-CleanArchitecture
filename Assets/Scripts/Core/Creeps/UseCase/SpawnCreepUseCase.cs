using UnityEngine;

public class SpawnCreepUseCase
{
    public void Spawn(CreepInWaveConfig creepInWaveConfig)
    {
        //TODO: call repository to get a new creep
        //TODO: configure creep
        Object.Instantiate(creepInWaveConfig.Creep.Prefab); //TODO: use pool
        Debug.Log("Creep spawned!");
    }
}