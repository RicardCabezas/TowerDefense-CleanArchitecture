using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Core.Turrets.UseCases;

namespace Core.Turrets.Views
{
    public class TurretThumbnailController
    {
        private readonly TurretsRepository _repository;
        private readonly TurretThumbnailView _view;
        private readonly string _turretId;
        private readonly SpawnTurretUseCase _spawnTurretUseCase;

        public TurretThumbnailController(
            TurretsRepository repository, 
            TurretThumbnailView view,
            string turretId)
        {
            _repository = repository;
            _view = view;
            _turretId = turretId;

            _spawnTurretUseCase = new SpawnTurretUseCase(_repository);
            
            _view.Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            //TODO: first spawn TurretPreviewer View -> on click call controller and call spawn turret usecase
            _spawnTurretUseCase.Spawn(_turretId); 
        }
    }
}