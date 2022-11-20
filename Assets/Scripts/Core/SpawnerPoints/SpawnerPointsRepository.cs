using System.Collections.Generic;
using UnityEngine;

public class SpawnerPointsRepository
{
    private Dictionary<string, Transform> _spawnerPoints = new Dictionary<string, Transform>();
    
    public SpawnerPointsRepository(SpawnerPointsConfig[] spawnerPointsConfigs)
    {
        foreach (var spawner in spawnerPointsConfigs)
        {
            _spawnerPoints[spawner.Id] = spawner.Transform;
        }
    }

    public Transform GetSpawnerPoint(string id)
    {
        return _spawnerPoints[id];
    }
}