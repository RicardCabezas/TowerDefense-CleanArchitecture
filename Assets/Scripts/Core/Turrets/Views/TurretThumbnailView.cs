using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Turrets.Views
{
    public class TurretThumbnailView : MonoBehaviour
    {
        public Text Price;
        public Button Button;
    }
    
    public class ProjectileView : MonoBehaviour
    {
    }

    public class ProjectilePresenter
    {
        private readonly TurretThumbnailView _view;

        public ProjectilePresenter(TurretThumbnailView view)
        {
            _view = view;
        }
    }

    public class ProjectileController
    {
        private readonly TurretThumbnailView _view;

        public ProjectileController(TurretThumbnailView view)
        {
            _view = view;
        }
        
        
        //TODO: get bullet config info
        //TODO: react to collision enter and call use case damage
    }
}