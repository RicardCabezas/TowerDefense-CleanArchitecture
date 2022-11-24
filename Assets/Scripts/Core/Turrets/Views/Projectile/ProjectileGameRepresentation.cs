using Core.Turrets.Controllers.Projectiles;
using Pool.BaseObjectRepresentation;

namespace Core.Turrets.Views.Projectile
{
    public class ProjectileRegularGameElementRepresentation : IGameElementRepresentation
    {
        public GameView GameView { get; set; }
        public BasePresenter Presenter { get; set; }
        public BaseViewController Controller { get; set; }
        public void Init(GameView view)
        {
            GameView = view;
            Controller = new ProjectileController(GameView as ProjectileView);
            Presenter = new ProjectilePresenter(GameView as ProjectileView);
        }
    }
    
    public class ProjectileFrozenGameElementRepresentation : IGameElementRepresentation
    {
        public GameView GameView { get; set; }
        public BasePresenter Presenter { get; set; }
        public BaseViewController Controller { get; set; }
        public void Init(GameView view)
        {
            GameView = view;
            Controller = new ProjectileFrozenController(GameView as ProjectileView);
            Presenter = new ProjectilePresenter(GameView as ProjectileView);
        }
    }
}