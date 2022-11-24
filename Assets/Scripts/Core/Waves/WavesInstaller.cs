using Core.Waves.Config;
using Core.Waves.Controllers;
using Core.Waves.Entity;
using Core.Waves.UseCase;
using Core.Waves.Views;
using UnityEngine;

namespace Core.Waves
{
    public class WavesInstaller : MonoBehaviour
    {
        public WavesLocalConfig WavesLocalConfig;
        public WavesView WavesView;

        public void Install()
        {
            var serviceLocator = ServiceLocator.ServiceLocator.Instance;

            var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig, WavesView); //TODO: change this
            serviceLocator.RegisterService(wavesRepository);

            var spawnWaveUseCase = new SpawnWaveUseCase(wavesRepository);
            var updateWaveUseCase = new UpdateWaveUseCase(wavesRepository, spawnWaveUseCase);

            var wavesController = new WavesController(updateWaveUseCase);
        
            spawnWaveUseCase.SpawnCreepsInWave();
        }
    }
}