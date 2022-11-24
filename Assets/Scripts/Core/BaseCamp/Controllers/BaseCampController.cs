using Core.BaseCamp.Events;
using Core.BaseCamp.UseCases;
using Events;

namespace Core.BaseCamp.Controllers
{
    public class BaseCampController
    {
        private readonly BaseCampReceivesDamageUseCase _baseCampReceivesDamageUseCase;
        private readonly IEventDispatcher _eventDispatcher;

        public BaseCampController(BaseCampReceivesDamageUseCase baseCampReceivesDamageUseCase)
        {
            _baseCampReceivesDamageUseCase = baseCampReceivesDamageUseCase;
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<BaseCampReceivedDamageEvent>(OnBaseCampReceivesDamage);
        }
        
        private void OnBaseCampReceivesDamage(BaseCampReceivedDamageEvent damageReceivedEvent)
        {
            _baseCampReceivesDamageUseCase.ReceiveDamage(damageReceivedEvent.Damage);
        }
    }
}