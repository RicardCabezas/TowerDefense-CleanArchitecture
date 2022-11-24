using UnityEngine;

public class CreepGameRepresentation :  IGameRepresentationInitializer
{
    public GameView GameView { get; set; }
    public BasePresenter Presenter { get; set; }
    public BaseViewController Controller { get; set; }

    public void Init(GameView view)
    {
        Debug.Log("");
        GameView = view;
        Controller = new BaseViewController();
        Presenter = new CreepPresenter(GameView as CreepView);
    }
}