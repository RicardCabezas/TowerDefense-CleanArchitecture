using Core.Turrets.Entities;
using Core.Turrets.Events;
using Events;

namespace Core.Turrets.UseCases
{
    public class SpawnTurretUseCase
    {
        private readonly TurretsRepository _repository;
        private readonly IEventDispatcher _eventDispatcher;

        public SpawnTurretUseCase(TurretsRepository repository)
        {
            _repository = repository;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        public void Spawn(string turretId)
        {
            _repository.GetNewTurretView(turretId); //TODO: get world position
            _eventDispatcher.Dispatch<TurretSpawned>();
        }
    }
}