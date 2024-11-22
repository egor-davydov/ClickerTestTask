using Code.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Gameplay.Click
{
  public class AutoClick : MonoBehaviour
  {
    [SerializeField] private Click _click;
    [SerializeField] private float _delay;

    public ClicksData ClicksInAutoClick { get; set; }
    private void Awake()
    {
      StartAutoClick().Forget();
    }

    private async UniTaskVoid StartAutoClick()
    {
      while (true)
      {
        await UniTask.WaitForSeconds(_delay).AttachExternalCancellation(destroyCancellationToken);
        _click.ClicksCount += ClicksInAutoClick;
      }
    }
  }
}