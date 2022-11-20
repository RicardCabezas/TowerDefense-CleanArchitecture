using System;
using UnityEngine;

[Serializable]
public class CreepConfig
{
    public float SpawnDelayInSeconds;


    //TODO: add projectile config
    //TODO: use config instance instead of prefab instance
    public float Speed;
    public GameObject Prefab;
}