public class WavesRepository
{
    //TODO: get configs
    
    public WaveConfig GetNextWave()
    {
        var currentWave = new WavesModel().CurrentWave;
        
        var wave = new WavesConfig().WaveConfigs[currentWave+1];

        return wave;
    }
}