public class SpawnWaveUseCase
{
    //TODO: have a wave model
    private readonly SpawnCreepUseCase _spawnCreepUseCase;

    public SpawnWaveUseCase(SpawnCreepUseCase spawnCreepUseCase)
    {
        _spawnCreepUseCase = spawnCreepUseCase;
    }

    public void SpawnWave()
    {
        //TODO: keep calling every X seconds (await or coroutine)
        _spawnCreepUseCase.Spawn();
    }
}