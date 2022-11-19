public class WavesService
{
    private readonly SpawnWaveUseCase _spawnWaveUseCase;

    public WavesService(SpawnWaveUseCase spawnWaveUseCase)
    {
        _spawnWaveUseCase = spawnWaveUseCase;
    }

    public void PrepareWaves()
    {
        //TODO: move 
        //TODO: keep calling when wave is finished (await or coroutine)
        _spawnWaveUseCase.SpawnWave();
    }
}