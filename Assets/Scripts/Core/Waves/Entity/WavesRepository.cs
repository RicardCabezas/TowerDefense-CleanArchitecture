using Core.Waves.Config;
using Core.Waves.Views;

namespace Core.Waves.Entity
{
    public class WavesRepository
    {
        private readonly WaveConfig[] _wavesConfig;
        private readonly WavesEntity _entity;

        public WavesRepository(WavesConfig wavesConfig, WavesView wavesView)
        {
            var presenter = new WavesPresenter(wavesView);

            _wavesConfig = wavesConfig.WaveConfigs;
            _entity = new WavesEntity
            {
                CurrentWave = 0,
                RemainingCreeps = _wavesConfig[0].CreepsConfig.Length
            };

        }

        public void UpdateCurrentWave()
        {
            _entity.CurrentWave += 1;
        }
    
        public WaveConfig GetNextWave()
        {
            var wave = _wavesConfig[_entity.CurrentWave];

            return wave;
        }
    
        public int GetCurrentWaveIndex()
        {
            return _entity.CurrentWave;
        }

        public bool IsLastWave()
        {
            return _entity.CurrentWave >= _wavesConfig.Length - 1;
        }
    
        public bool IsWaveCompleted()
        {
            return _entity.RemainingCreeps == 0;
        }

        public int DecreaseRemainingCreeps()
        {
            _entity.RemainingCreeps -= 1;
            return _entity.RemainingCreeps;
        }

        public void ResetRemainingCreeps()
        {
            _entity.RemainingCreeps = _wavesConfig[_entity.CurrentWave].CreepsConfig.Length;
        }

        public object GetRemainingCreeps()
        {
            return _entity.RemainingCreeps;
        }
    }
}