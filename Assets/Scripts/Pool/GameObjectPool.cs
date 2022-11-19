using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameObjectPool<T> where T : PoolableObject
{
    private readonly T _prefab;
    
    private readonly HashSet<T> _instantiatedObjects;
    private readonly Queue<T> _pooledInactiveObjects;

    public GameObjectPool(T prefab, int defaultNumberOfObjects)
    {
        _prefab = prefab;
        _instantiatedObjects = new HashSet<T>();
        _pooledInactiveObjects = new Queue<T>(defaultNumberOfObjects);
        
        for (var i = 0; i < defaultNumberOfObjects; i++)
        {
            var instance = InstantiateNewPooledObject();
            instance.gameObject.SetActive(false);
            _pooledInactiveObjects.Enqueue(instance);
        }
    }

    public T Get()
    {
        var pooledObject = GetPooledObject();
        _instantiatedObjects.Add(pooledObject);
        
        pooledObject.gameObject.SetActive(true);
        pooledObject.Init();
        return pooledObject;
    }
    
    public void Release(T pooledObject)
    {
        var wasInstantiated = _instantiatedObjects.Remove(pooledObject);
        Assert.IsTrue(wasInstantiated, "Trying to release non spawned pooled object"); //TODO: check asserts
            
        pooledObject.gameObject.SetActive(false);
        pooledObject.Release();
        _pooledInactiveObjects.Enqueue(pooledObject);
    }

    private T GetPooledObject()
    {
        if (_pooledInactiveObjects.Count > 0)
        {
            return _pooledInactiveObjects.Dequeue();
        }
        
        var instance = InstantiateNewPooledObject();
        _pooledInactiveObjects.Enqueue(instance);
        
        return instance;
    }
    
    private T InstantiateNewPooledObject()
    {
        var instance = Object.Instantiate(_prefab);
        return instance;
    }
}