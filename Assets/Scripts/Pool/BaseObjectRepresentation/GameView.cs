using System;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public Action Dispose;

    public void Init()
    {
    }
    
    private void OnDestroy()
    {
        Dispose?.Invoke();
    }
}