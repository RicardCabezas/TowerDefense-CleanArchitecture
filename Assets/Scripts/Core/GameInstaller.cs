using UnityEngine;
using ScreenMachine;
using States;

public class GameInstaller : MonoBehaviour
{
    void Start()
    {
        var creepRepository = new CreepRepository();
        var wavesRepository = new WavesRepository();
        
        var spawnCreepUseCase = new SpawnCreepUseCase();
        var spawnWaveUseCase = new SpawnWaveUseCase(spawnCreepUseCase);
        var wavesService = new WavesService(wavesRepository, spawnWaveUseCase);

        var screenMachine = new ScreenMachineImplementation();
        
        screenMachine.PushState(new GameplayState(screenMachine, wavesService));
    }
}