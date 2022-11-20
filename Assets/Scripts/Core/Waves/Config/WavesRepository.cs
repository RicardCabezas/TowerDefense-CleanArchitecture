public class WavesRepository
{
    private readonly WavesConfig _wavesConfig;
    private readonly WavesModel _model;

    public WavesRepository(WavesConfig wavesConfig)
    {
        _wavesConfig = wavesConfig;
        _model = new WavesModel();
    }


    public void UpdateCurrentWave()
    {
        _model.CurrentWave += 1;
    }
    
    public WaveConfig GetNextWave()
    {
        var wave = _wavesConfig.WaveConfigs[_model.CurrentWave];

        return wave;
    }
}