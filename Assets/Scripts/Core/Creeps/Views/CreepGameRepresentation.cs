using Pool.BaseObjectRepresentation;

namespace Core.Creeps.Views
{
    public class CreepGameElementRepresentation :  IGameElementRepresentation
    {
        public GameView GameView { get; set; }
        public BasePresenter Presenter { get; set; }
        public BaseViewController Controller { get; set; }

        public void Init(GameView view)
        {
            GameView = view;
            Controller = new BaseViewController();
            Presenter = new CreepPresenter(GameView as CreepView);
        }
    }
}