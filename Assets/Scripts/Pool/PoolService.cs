using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

public static class PoolService
{
    private static readonly Dictionary<Type, Stack<IGameRepresentationInitializer>> _pooledObjects = new Dictionary<Type, Stack<IGameRepresentationInitializer>>();
    private static readonly GameObject _poolParent;

    public static IGameRepresentationInitializer Get<T>()
    {
        if (!_pooledObjects.TryGetValue(typeof(T), out var gameRepresentationObjectOfTypeT))
        {
            return null;
        }
        
        if (gameRepresentationObjectOfTypeT.Count <= 0)
        {
            return null;
        }
        
        return gameRepresentationObjectOfTypeT.Pop();
    }
    
    public static void StoreGameRepresentationObject(Type objectType, IGameRepresentationInitializer gameRepresentationObject)
    {
        gameRepresentationObject.GameView.gameObject.SetActive(false);
            
        if (!_pooledObjects.TryGetValue(objectType, out var controllerViewPairStackOfTypeT))
        {
            var stack = new Stack<IGameRepresentationInitializer>();
            stack.Push(gameRepresentationObject);
            _pooledObjects.Add(objectType, stack);
        }
        else
        {
            controllerViewPairStackOfTypeT.Push(gameRepresentationObject);
        }
    }

}