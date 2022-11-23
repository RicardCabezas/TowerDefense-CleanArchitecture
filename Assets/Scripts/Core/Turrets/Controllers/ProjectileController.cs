namespace Core.Turrets.Views
{
    public class ProjectileController
    {
        private readonly ProjectileView _view;

        public ProjectileController(ProjectileView view)
        {
            _view = view;
        }
        
        
        //TODO: get bullet config info
        //TODO: react to collision enter and call use case damage
    }
}