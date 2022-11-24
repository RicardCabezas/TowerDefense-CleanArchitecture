using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

public static class PoolService
{
    private static readonly Dictionary<Type, Stack<IGameElementRepresentation>> _pooledObjects = new Dictionary<Type, Stack<IGameElementRepresentation>>();
    private static readonly GameObject _poolParent;

    public static IGameElementRepresentation Get<T>()
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
    
    public static void StoreGameRepresentationObject<T>(IGameElementRepresentation gameElementRepresentationObject)
    {
        gameElementRepresentationObject.GameView.gameObject.SetActive(false);
        gameElementRepresentationObject.Controller.Dispose();
        gameElementRepresentationObject.Presenter.Dispose();
        if (!_pooledObjects.TryGetValue(typeof(T), out var controllerViewPairStackOfTypeT))
        {
            var stack = new Stack<IGameElementRepresentation>();
            stack.Push(gameElementRepresentationObject);
            _pooledObjects.Add(typeof(T), stack);
        }
        else
        {
            controllerViewPairStackOfTypeT.Push(gameElementRepresentationObject);
        }
    }

}