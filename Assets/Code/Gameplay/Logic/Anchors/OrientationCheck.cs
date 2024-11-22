using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Gameplay.Logic.Anchors
{
  public class OrientationCheck : MonoBehaviour
  {
    public static event Action<ScreenOrientation> OnOrientationChange;
    [SerializeField] private float _checkDelay = 0.3f;

    private ScreenOrientation _orientation;

    private void Awake()
    {
      CheckForChange().Forget();
    }

    private async UniTaskVoid CheckForChange()
    {
      _orientation = Screen.orientation;

      while (true)
      {
        if (_orientation != Screen.orientation)
        {
          _orientation = Screen.orientation;
          OnOrientationChange?.Invoke(_orientation);
        }
        await UniTask.WaitForSeconds(_checkDelay).AttachExternalCancellation(destroyCancellationToken);
      }
    }
  }
}