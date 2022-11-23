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
        private readonly TurretSpawnerPreviewerController _previewerController;

        public TurretThumbnailController(
            TurretsRepository repository, 
            TurretThumbnailView view,
            string turretId,
            TurretSpawnerPreviewerController previewerController)
        {
            _repository = repository;
            _view = view;
            _previewerController = previewerController;

            var spawnTurretUseCase = new SpawnTurretUseCase(_repository);
            
            _view.Button.onClick.AddListener(OnClick);
            
            _previewerController.Init(spawnTurretUseCase, turretId);
        }

        private void OnClick()
        {
            _previewerController.gameObject.SetActive(true); //TODO: move to container
            //TODO: first spawn TurretPreviewer View -> on click call controller and call spawn turret usecase
        }
    }
}