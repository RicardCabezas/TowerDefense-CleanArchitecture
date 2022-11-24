using Pool.BaseObjectRepresentation;
using UnityEngine;

namespace Core.Turrets.Views.Turret
{
    public class TurretGameElementRepresentation : IGameElementRepresentation
    {
        public GameView GameView { get; set; }
        public BasePresenter Presenter { get; set; }
        public BaseViewController Controller { get; set; }
        public void Init(GameView view)
        {
            GameView = view;
            Controller = new BaseViewController();
            Presenter = new TurretPresenter(GameView as TurretView);
        }

        public void SetInitialPosition(Vector3 position)
        {
            ((TurretPresenter)Presenter).UpdatePosition(position);
        }
    }
}