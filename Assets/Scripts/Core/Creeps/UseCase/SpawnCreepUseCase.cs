using UnityEngine;

public class SpawnCreepUseCase
{
    private readonly CreepRepository _creepRepository;
    private readonly SpawnerPointsRepository _spawnerPointsRepository;

    public SpawnCreepUseCase(CreepRepository creepRepository, SpawnerPointsRepository spawnerPointsRepository)
    {
        _creepRepository = creepRepository;
        _spawnerPointsRepository = spawnerPointsRepository;
    }

    public void Spawn(CreepInWaveConfig creepInWaveConfig)
    {
        var creep = _creepRepository.GetNewCreep(creepInWaveConfig.CreepId);
        var spawner = _spawnerPointsRepository.GetSpawnerPoint(creepInWaveConfig.SpawnPointId);

        creep.transform.position = spawner.position;
    }
}