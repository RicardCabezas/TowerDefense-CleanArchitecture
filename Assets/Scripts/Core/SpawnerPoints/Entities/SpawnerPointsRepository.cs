using System.Collections.Generic;
using Core.SpawnerPoints.Entities;
using Core.SpawnerPoints.Views;
using UnityEngine;

public class SpawnerPointsRepository
{
    private Dictionary<string, SpawnerPointEntity> _spawnerPoints = new Dictionary<string, SpawnerPointEntity>(); 
    
    public SpawnerPointsRepository(SpawnerPointsConfig[] spawnerPointsConfigs)
    {
        foreach (var spawner in spawnerPointsConfigs)
        {
            _spawnerPoints[spawner.Id] = new SpawnerPointEntity
            {
                Position = spawner.View.transform.position
            };

            new SpawnerPresenter(spawner.View);
        }
    }

    public Vector3 GetSpawnerPointPosition(string id)
    {
        return _spawnerPoints[id].Position;
    }
}