using Code.Data;
using Code.Gameplay;
using UnityEngine;

namespace Code.UI.Elements.Upgrades
{
  public class UpgradesContainer : MonoBehaviour
  {
    [SerializeField] private Click _click;
    private void Awake()
    {
      _click.OnCountChanged += SetInteractable;
      SetInteractable(_click.ClicksCount);
    }

    private void SetInteractable(ClicksData clicksData)
    {
      foreach (UpgradeButton upgradeButton in GetComponentsInChildren<UpgradeButton>())
        upgradeButton.Button.interactable = upgradeButton.CanAfford(clicksData);
    }
  }
}