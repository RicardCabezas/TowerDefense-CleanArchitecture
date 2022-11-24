
using System;
using System.Threading.Tasks;
using Core.Waves.Events;
using Events;

public class SpawnWaveUseCase
{
    private readonly IEventDispatcher _eventDispatcher;
    private readonly WavesRepository _wavesRepository;
    private readonly CreepRepository _creepRepository;
    private readonly SpawnerPointsRepository _spawnerPointsRepository;

    public SpawnWaveUseCase(WavesRepository wavesRepository)
    {
        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        _wavesRepository = wavesRepository;
        _creepRepository = ServiceLocator.Instance.GetService<CreepRepository>();
        _spawnerPointsRepository = ServiceLocator.Instance.GetService<SpawnerPointsRepository>();
    }

    public async void SpawnCreepsInWave()
    {
        var nextWave = _wavesRepository.GetNextWave();
        
        foreach (var creep in nextWave.CreepsConfig)
        {
            await Task.Delay(creep.SpawnDelayInMiliseconds);
            
            var spawnerPosition = _spawnerPointsRepository.GetSpawnerPointPosition(creep.SpawnPointId);
            var creepEntity = _creepRepository.SpawnNewCreep(creep.CreepId, spawnerPosition);
            
            _eventDispatcher.Dispatch(new CreepSpawnedEvent(creepEntity));
        }
    }
}