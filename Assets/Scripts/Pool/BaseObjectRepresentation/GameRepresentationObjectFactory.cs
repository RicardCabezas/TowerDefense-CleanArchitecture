using UnityEngine;

namespace Pool.BaseObjectRepresentation
{
    public static class GameRepresentationObjectFactory
    {
        public static T GameRepresentationObject<T>(GameView gameplayViewBase, object args = null) 
            where T : IGameElementRepresentation, new()
        {
            var gameRepresentationObject = PoolService.Get<T>();
            if (gameRepresentationObject != null)
            {
                var view = gameRepresentationObject.GameView;
                
                view.gameObject.SetActive(true);
                return (T)gameRepresentationObject;
            }

            var newGameRepresentationObject = new T();

            var viewInstance = Object.Instantiate(gameplayViewBase);
            newGameRepresentationObject.Init(viewInstance);
            return newGameRepresentationObject;
        }
    }
}