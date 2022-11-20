using System.Threading.Tasks;
using UnityEngine;

public class SpawnCreepUseCase
{
    private readonly MoveCreepUseCase _moveCreepUseCase;
    private readonly CreepRepository _creepRepository;
    private readonly SpawnerPointsRepository _spawnerPointsRepository;

    public SpawnCreepUseCase(
        MoveCreepUseCase moveCreepUseCase,
        CreepRepository creepRepository,
        SpawnerPointsRepository spawnerPointsRepository)
    {
        _moveCreepUseCase = moveCreepUseCase;
        _creepRepository = creepRepository;
        _spawnerPointsRepository = spawnerPointsRepository;
    }

    public void Spawn(CreepInWaveConfig creepInWaveConfig)
    {
        var creep = _creepRepository.GetNewCreep(creepInWaveConfig.CreepId);
        var config = _creepRepository.GetCreepConfig(creepInWaveConfig.CreepId);
        
        var spawner = _spawnerPointsRepository.GetSpawnerPoint(creepInWaveConfig.SpawnPointId);
        creep.transform.position = spawner.position;
        
        //TODO: listen event of creep spawned instead of direct call to decouple
        _moveCreepUseCase.Move(creep, config.Speed);
    }
}

public class MoveCreepUseCase
{
    private readonly Transform _userBaseTransform;

    public MoveCreepUseCase(Transform userBaseTransform)
    {
        _userBaseTransform = userBaseTransform;
    }
    public async void Move(CreepView creep, float speed)
    {
        while (Vector3.Distance(creep.transform.position, _userBaseTransform.position) >= 1)
        {
            var newCreepPosition = Vector3.MoveTowards(
                creep.transform.position, _userBaseTransform.position, speed * Time.deltaTime);
            creep.transform.position = newCreepPosition;
            await Task.Yield();
        }
    }
}