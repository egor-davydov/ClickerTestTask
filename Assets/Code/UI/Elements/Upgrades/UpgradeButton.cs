using System;
using Code.Data;
using UnityEngine;

namespace Code.UI.Elements.Upgrades
{
  public abstract class UpgradeButton : ButtonHandler
  {
    [SerializeField] private ClicksData _priceData;
    
    public event Action<ClicksData> OnPriceChanged;

    public ClicksData PriceData
    {
      get => _priceData;
      set
      {
        _priceData = value;
        OnPriceChanged?.Invoke(_priceData);
      }
    }

    public bool CanAfford(ClicksData clicksData) => 
      clicksData.Value >= PriceData.Value;
  }
}