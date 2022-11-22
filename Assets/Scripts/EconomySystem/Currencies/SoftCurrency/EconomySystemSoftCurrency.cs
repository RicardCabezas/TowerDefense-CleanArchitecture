public class EconomySystemSoftCurrency : IEconomySystem<SoftCurrency>
{
    public float CurrentAmount { get; private set; }

    public void AddCurrency(float amount)
    {
        CurrentAmount += amount;
    }

    public void SubtractCurrency(float amount)
    {
        CurrentAmount -= amount;
    }
}