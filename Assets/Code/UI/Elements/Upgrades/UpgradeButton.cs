using System;
using Code.Data;
using DG.Tweening;
using UnityEngine;

namespace Code.UI.Elements.Upgrades
{
  public abstract class UpgradeButton : ButtonHandler
  {
    [SerializeField] private ClicksData _priceData;
    [SerializeField] private float _scaleAnimationTime = 0.1f;
    [SerializeField] private float _scaleAnimationMultiplier = 1.1f;
    
    private Sequence _tween;

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
      clicksData >= PriceData;

    public override void OnClick()
    {
      _tween.Kill();
      _tween = DOTween.Sequence()
        .Append(transform.DOScale(Vector3.one * _scaleAnimationMultiplier, _scaleAnimationTime).From(Vector3.one))
        .Append(transform.DOScale(Vector3.one, _scaleAnimationTime))
        .SetLink(gameObject);
    }
  }
}