public class WavesService
{
    private readonly WavesRepository _wavesRepository;
    private readonly SpawnWaveUseCase _spawnWaveUseCase;

    public WavesService(WavesRepository wavesRepository, SpawnWaveUseCase spawnWaveUseCase)
    {
        _wavesRepository = wavesRepository;
        _spawnWaveUseCase = spawnWaveUseCase;
    }

    public void PrepareWave()
    {
        var nextWave = _wavesRepository.GetNextWave(); //TODO: create wave factory
        _spawnWaveUseCase.SpawnWave(nextWave);
    }
    
    //TODO: listen for event of all creeps killed to spawn next wave
    void OnWaveFinished()
    {
        //TODO: check if it was last wave
        PrepareWave();
    }
}