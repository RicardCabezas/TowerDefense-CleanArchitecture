using Core.Turrets.Entities;
using Core.Turrets.UseCases;

namespace Core.Turrets.Views
{
    public class TurretThumbnailController
    {
        private TurretsRepository _repository;
        private TurretThumbnailView _view;
        private string _turretId;
        private TurretSpawnerPreviewerController _previewerController;

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

            _view.Dispose += OnViewDisposed;
        }

        private void OnViewDisposed()
        {
            _view.Button.onClick.RemoveAllListeners();
            _view = null;
            _previewerController = null;
            _repository = null;
            _turretId = null;
        }

        private void OnClick()
        {
            _previewerController.gameObject.SetActive(true); //TODO: move to container
            //TODO: first spawn TurretPreviewer View -> on click call controller and call spawn turret usecase
        }
    }
}