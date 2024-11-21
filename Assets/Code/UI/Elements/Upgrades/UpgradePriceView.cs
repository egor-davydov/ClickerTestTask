using Code.Data;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements.Upgrades
{
  public class UpgradePriceView : MonoBehaviour
  {
    [SerializeField] private UpgradeButton _upgradeButton;
    [SerializeField] private TextMeshProUGUI _priceTMP;

    private void Awake()
    {
      _upgradeButton.OnPriceChanged += SetPrice;
      SetPrice(_upgradeButton.PriceData);
    }

    private void SetPrice(ClicksData price)
    {
      _priceTMP.text = $"Price: {price.Value}";
    }
  }
}