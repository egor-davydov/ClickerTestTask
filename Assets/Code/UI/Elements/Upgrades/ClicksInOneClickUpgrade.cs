using Code.Data;
using Code.Gameplay.Click;
using UnityEngine;

namespace Code.UI.Elements.Upgrades
{
  public class ClicksInOneClickUpgrade : UpgradeButton
  {
    [SerializeField] private Click _click;
    
    public ClicksData ClicksToAdd { get; } = new(1);

    public override void OnClick()
    {
      if (!CanAfford(_click.ClicksCount))
        return;
      
      _click.ClicksInOneClick += ClicksToAdd;
      _click.ClicksCount -= PriceData;
      PriceData *= new ClicksData(3);
    }
  }
}