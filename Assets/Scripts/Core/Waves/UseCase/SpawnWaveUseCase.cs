using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnWaveUseCase
{
    //TODO: have a wave model
    private readonly SpawnCreepUseCase _spawnCreepUseCase;

    public SpawnWaveUseCase(SpawnCreepUseCase spawnCreepUseCase)
    {
        _spawnCreepUseCase = spawnCreepUseCase;
    }

    public async void SpawnWave(WaveConfig waveConfig)
    {
        //TODO: keep calling every X seconds (await or coroutine)
        await SpawnCreeps(waveConfig);
    }

    async Task SpawnCreeps(WaveConfig waveConfig)
    {
        foreach (var creep in waveConfig.CreepsConfig)
        {
            await Task.Delay(creep.SpawnDelayInMiliseconds);
            _spawnCreepUseCase.Spawn(creep);
        }
    }
}