namespace Core.Turrets.Views
{
    public class ProjectileGameElementRepresentation : IGameElementRepresentation
    {
        public GameView GameView { get; set; }
        public BasePresenter Presenter { get; set; }
        public BaseViewController Controller { get; set; }
        public void Init(GameView view)
        {
            GameView = view;
            Controller = new BaseViewController();
            Presenter = new ProjectilePresenter(GameView as ProjectileView);
        }
    }
}