public class EconomySystemSoftCurrency : IEconomySystem<SoftCurrency>
{
    public int CurrentAmount { get; private set; }

    public void AddCurrency(int amount)
    {
        CurrentAmount += amount;
    }

    public void SubtractCurrency(int amount)
    {
        CurrentAmount -= amount;
    }
}