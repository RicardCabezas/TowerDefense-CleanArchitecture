public class GameRepresentationObject
{
  
}

public interface IGameRepresentationInitializer
{
    public GameView GameView { get; set; }
    public BasePresenter Presenter { get; set; }
    public BaseViewController Controller { get; set; }
    void Init(GameView view);
}