using Core.Currencies.Events;
using Core.Turrets.Entities;
using Core.Turrets.UseCases;
using Core.Turrets.Views.Thumbnail;
using Events;

namespace Core.Turrets.Controllers.SpawnTurret
{
    public class TurretThumbnailController
    {
        private TurretsRepository _repository;
        private TurretThumbnailView _view;
        private string _turretId;
        private TurretSpawnerPreviewerController _previewerController;
        private readonly IEventDispatcher _eventDispatcher;

        public TurretThumbnailController(
            TurretsRepository repository, 
            TurretThumbnailView view,
            string turretId,
            TurretSpawnerPreviewerController previewerController)
        {
            _repository = repository;
            _view = view;
            _turretId = turretId;
            _previewerController = previewerController;
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();

            _view.Button.onClick.AddListener(OnClick);
            _eventDispatcher.Subscribe<UpdateSoftCurrencyEvent>(OnSoftCurrencyUpdated);
            _view.Dispose += OnViewDisposed;

            var spawnTurretUseCase = new SpawnTurretUseCase(_repository);
            _previewerController.Init(spawnTurretUseCase);
        }

        private void OnSoftCurrencyUpdated(UpdateSoftCurrencyEvent eventInfo)
        {
            //TODO: call a use case to control the interactability of the buttons
            //Avoid purchases if not enough currency
        }

        private void OnViewDisposed()
        {
            _view.Button.onClick.RemoveAllListeners();
            _eventDispatcher.Unsubscribe<UpdateSoftCurrencyEvent>(OnSoftCurrencyUpdated);
            _view = null;
            _previewerController = null;
            _repository = null;
            _turretId = null;
        }

        private void OnClick()
        {
            _previewerController.gameObject.SetActive(true);
            _previewerController.ThumbnailPressed(_turretId);
        }
    }
}