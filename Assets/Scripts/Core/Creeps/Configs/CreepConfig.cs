using System;
using UnityEngine;

[Serializable]

public class CreepConfig
{
    //TODO: add projectile config
    //TODO: use config instance instead of prefab instance
    public float Speed;
    public float Health;
    public CreepView Prefab;
    public string Id;
}