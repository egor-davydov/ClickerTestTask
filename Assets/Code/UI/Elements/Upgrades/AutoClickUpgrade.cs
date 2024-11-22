using Code.Data;
using Code.Gameplay.Click;
using UnityEngine;

namespace Code.UI.Elements.Upgrades
{
  public class AutoClickUpgrade : UpgradeButton
  {
    [SerializeField] private AutoClick _autoClick;
    [SerializeField] private Click _click;

    public ClicksData ClicksToAdd { get; } = new(1);

    public override void OnClick()
    {
      base.OnClick();
      _autoClick.ClicksInAutoClick += ClicksToAdd;
      _click.ClicksCount -= PriceData;
      PriceData *= new ClicksData(3);
    }
  }
}