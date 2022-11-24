using Core.Currencies.Events;
using Core.Turrets.Entities;
using Core.Turrets.Events;
using EconomySystem;
using EconomySystem.Currencies.SoftCurrency;
using Events;
using UnityEngine;

namespace Core.Turrets.UseCases
{
    public class SpawnTurretUseCase
    {
        private readonly TurretsRepository _repository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IEconomySystem<SoftCurrency> _softCurrency;

        public SpawnTurretUseCase(TurretsRepository repository)
        {
            _repository = repository;
            
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            _softCurrency = ServiceLocator.ServiceLocator.Instance.GetService<IEconomySystem<SoftCurrency>>();
        }

        public void Spawn(string turretId, Vector3 position)
        {
            var turret = _repository.SpawnNewTurret(turretId, position);
            _eventDispatcher.Dispatch(new TurretSpawned(turret));
            
            _softCurrency.SubtractCurrency(turret.Cost);
            _eventDispatcher.Dispatch(new UpdateSoftCurrencyEvent(_softCurrency.CurrentAmount));
        }
    }
}