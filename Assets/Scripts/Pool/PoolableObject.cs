using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
    internal abstract void Init();
    internal abstract void Release();
}