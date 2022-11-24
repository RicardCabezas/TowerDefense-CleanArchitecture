using EconomySystem.Currencies;

namespace EconomySystem
{
    public interface IEconomySystem<T> where T: Currency
    {
        int CurrentAmount { get; }
        void AddCurrency(int amount);
        void SubtractCurrency(int amount);
    }
}