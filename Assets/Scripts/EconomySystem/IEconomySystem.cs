using System.Collections;
using System.Collections.Generic;

public interface IEconomySystem<T> where T: Currency
{
    float CurrentAmount { get; }
    void AddCurrency(float amount);
    void SubtractCurrency(float amount);
}