using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements.Loading
{
  public class Loading : MonoBehaviour
  {
    private const int DotsCount = 3;

    [SerializeField] private TextMeshProUGUI _loadingTMP;
    [SerializeField] private float _dotsAnimationTime;
    [SerializeField] private float _restartAnimationDelay;
    [SerializeField] private float _skipButtonWaitTime;
    [SerializeField] private GameObject _skipButtonObject;
    
    private string _startLoadingText;

    private void Awake()
    {
      _startLoadingText = _loadingTMP.text;
      _skipButtonObject.SetActive(false);
      StartLoadingTextAnimation().Forget();
      EnableSkipButtonAfterWait().Forget();
    }

    private async UniTaskVoid EnableSkipButtonAfterWait()
    {
      await UniTask.WaitForSeconds(_skipButtonWaitTime).AttachExternalCancellation(destroyCancellationToken);
      _skipButtonObject.SetActive(true);
    }

    private async UniTaskVoid StartLoadingTextAnimation()
    {
      while (true)
      {
        for (int i = 0; i < DotsCount; i++)
        {
          await UniTask.WaitForSeconds(_dotsAnimationTime / DotsCount).AttachExternalCancellation(destroyCancellationToken);
          _loadingTMP.text += '.';
        }

        await UniTask.WaitForSeconds(_restartAnimationDelay).AttachExternalCancellation(destroyCancellationToken);
        _loadingTMP.text = _startLoadingText;
      }
    }
  }
}