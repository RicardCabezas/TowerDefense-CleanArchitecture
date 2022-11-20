public class WavesService
{
    private readonly WavesRepository _wavesRepository;
    private readonly SpawnWaveUseCase _spawnWaveUseCase;

    public WavesService(WavesRepository wavesRepository, SpawnWaveUseCase spawnWaveUseCase)
    {
        _wavesRepository = wavesRepository;
        _spawnWaveUseCase = spawnWaveUseCase;
    }

    public void PrepareWaves()
    {
        //TODO: move 
        //TODO: keep calling when wave is finished (await or coroutine)
        _spawnWaveUseCase.SpawnWave();
    }
}