using System;
using UnityEngine;

namespace Pool.BaseObjectRepresentation
{
    public class GameView : MonoBehaviour
    {
        public Action Dispose;

        private void OnDestroy()
        {
            Dispose?.Invoke();
        }
    }
}