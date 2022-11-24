using System;
using UnityEngine;

namespace Pool.BaseObjectRepresentation
{
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
}