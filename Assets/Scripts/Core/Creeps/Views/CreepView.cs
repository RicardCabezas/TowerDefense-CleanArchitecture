using UnityEngine;

public class CreepView : PoolableObject
{
    public string RemainingHealth;
    public Vector3 Position;
    public Color Color;
    internal override void Init()
    {
        //TODO: update position
    }

    internal override void Release()
    {
    }
}