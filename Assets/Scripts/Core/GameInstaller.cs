using UnityEngine;
using ScreenMachine;

public class GameInstaller : MonoBehaviour
{
    void Start()
    {
        //Waves
        var creepRepository = new CreepRepository();
        
        var spawnCreepUseCase = new SpawnCreepUseCase();
        var spawnWaveUseCase = new SpawnWaveUseCase(spawnCreepUseCase);
        var levelWavesController = new WavesInLevelUseCase(spawnWaveUseCase);

        var screenMachine = new ScreenMachineImplementation();
    }
}