public class WavesInLevelUseCase
{
    private readonly SpawnWaveUseCase _spawnWaveUseCase;

    public WavesInLevelUseCase(SpawnWaveUseCase spawnWaveUseCase)
    {
        _spawnWaveUseCase = spawnWaveUseCase;
    }

    public void PrepareWaves()
    {
        //TODO: keep calling when wave is finished (await or coroutine)
        _spawnWaveUseCase.SpawnWave();
    }
}