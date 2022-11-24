using Events;

namespace Core.Currencies.Events
{
    public class UpdateSoftCurrencyEvent : BaseEvent
    {
        public int CurrentAmount { get; }

        public UpdateSoftCurrencyEvent(int currentAmount)
        {
            CurrentAmount = currentAmount;
        }
    }
}