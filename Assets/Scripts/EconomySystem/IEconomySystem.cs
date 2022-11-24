using System.Collections;
using System.Collections.Generic;

public interface IEconomySystem<T> where T: Currency
{
    int CurrentAmount { get; }
    void AddCurrency(int amount);
    void SubtractCurrency(int amount);
}