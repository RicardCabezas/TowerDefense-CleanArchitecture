
using System.Threading.Tasks;
using Core.Waves.Events;
using Events;

public class SpawnWaveUseCase
{
    private readonly IEventDispatcher _eventDispatcher;
    private readonly WavesRepository _wavesRepository;
    private readonly CreepRepository _creepRepository;
    private readonly SpawnerPointsRepository _spawnerPointsRepository;

    public SpawnWaveUseCase(
        IEventDispatcher eventDispatcher,
        WavesRepository wavesRepository,
        CreepRepository creepRepository, SpawnerPointsRepository spawnerPointsRepository)
    {
        _eventDispatcher = eventDispatcher;
        _wavesRepository = wavesRepository;
        _creepRepository = creepRepository;
        _spawnerPointsRepository = spawnerPointsRepository;
    }

    public async void SpawnCreepsInWave()
    {
        var nextWave = _wavesRepository.GetNextWave();
        
        var nextWaveIndex = _wavesRepository.GetCurrentWaveIndex();
        _eventDispatcher.Dispatch(new WaveSpawnedEvent(nextWaveIndex));

        foreach (var creep in nextWave.CreepsConfig)
        {
            await Task.Delay(creep.SpawnDelayInMiliseconds);
            
            var spawnerPosition = _spawnerPointsRepository.GetSpawnerPointPosition(creep.SpawnPointId);
            var creepEntity = _creepRepository.SpawnNewCreep(creep.CreepId, spawnerPosition);
            
            _eventDispatcher.Dispatch(new CreepSpawnedEvent(creepEntity));
        }
    }
    
    
    //TODO: listen for event of all creeps killed to spawn next wave
    void OnWaveFinished()
    {
        //TODO: check if it was last wave
        SpawnCreepsInWave();
    }
}