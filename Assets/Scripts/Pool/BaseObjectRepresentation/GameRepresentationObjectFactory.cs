using UnityEngine;

public static class GameRepresentationObjectFactory
{
    public static T GameRepresentationObject<T>(GameView gameplayViewBase, object args = null) 
        where T : IGameRepresentationInitializer, new()
    {
        var gameRepresentationObject = PoolService.Get<T>();
        if (gameRepresentationObject != null)
        {
            var view = gameRepresentationObject.GameView;
            var presenter = gameRepresentationObject.Presenter;
            var controller = gameRepresentationObject.Controller;

            view.gameObject.SetActive(true);
            controller.Init(view, args);
            presenter.Init(view, args);
            view.Init();
            return (T)gameRepresentationObject;
        }

        var newGameRepresentationObject = new T();

        var viewInstance = Object.Instantiate(gameplayViewBase);
        newGameRepresentationObject.Init(viewInstance);
        return newGameRepresentationObject;
    }
}