using UnityEngine;
using ScreenMachine;
using States;

public class GameInstaller : MonoBehaviour
{
    void Start()
    {
        //Waves
        var creepRepository = new CreepRepository();
        
        var spawnCreepUseCase = new SpawnCreepUseCase();
        var spawnWaveUseCase = new SpawnWaveUseCase(spawnCreepUseCase);
        var wavesService = new WavesService(spawnWaveUseCase);

        var screenMachine = new ScreenMachineImplementation();
        
        screenMachine.PushState(new GameplayState(screenMachine, wavesService));
    }
}