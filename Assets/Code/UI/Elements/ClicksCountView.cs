using Code.Data;
using Code.Gameplay.Click;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
  public class ClicksCountView : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _clicksCountTMP;
    [SerializeField] private Click _click;

    private void Awake()
    {
      _click.OnCountChanged += SetClicksCount;
      SetClicksCount(_click.ClicksCount);
    }

    private void SetClicksCount(ClicksData clicksData)
    {
      _clicksCountTMP.text = clicksData.Value.ToString();
    }
  }
}