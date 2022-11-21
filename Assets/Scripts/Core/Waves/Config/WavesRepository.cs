using Core.Waves;

public class WavesRepository
{
    private readonly WavesConfig _wavesConfig;
    private readonly WavesEntity _entity;

    public WavesRepository(WavesConfig wavesConfig, WavesView wavesView)
    {
        _wavesConfig = wavesConfig;
        _entity = new WavesEntity();

        var presenter = new WavesPresenter(wavesView);
    }

    public void UpdateCurrentWave()
    {
        _entity.CurrentWave += 1;
    }
    
    public WaveConfig GetNextWave()
    {
        var wave = _wavesConfig.WaveConfigs[_entity.CurrentWave];

        return wave;
    }
    
    public int GetCurrentWaveIndex()
    {
        return _entity.CurrentWave;
    }
}