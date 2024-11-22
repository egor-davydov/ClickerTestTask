using System;
using Code.Data;
using Cysharp.Threading.Tasks;
using Fluxy;
using UnityEngine;

namespace Code.Gameplay.Click
{
  public class Click : MonoBehaviour
  {
    [SerializeField] private ClickInput _clickInput;
    [SerializeField] private ClickColor _clickColor;
    [SerializeField] private FluxyTarget _fluxyTarget;
    
    private Camera _camera;
    private ClicksData _clicksCount;

    public event Action<ClicksData> OnCountChanged;

    public ClicksData ClicksCount
    {
      get => _clicksCount;
      set
      {
        if (_clicksCount == value)
          return;
        _clicksCount = value;
        OnCountChanged?.Invoke(_clicksCount);
      }
    }

    public ClicksData ClicksInOneClick { get; set; } = new(1);

    private void Awake()
    {
      _clickInput.Started += ClickStarted;
      _camera = Camera.main;
    }

    private void ClickStarted(Vector2 clickPosition)
    {
      Vector3 worldPoint = _camera.ScreenToWorldPoint(clickPosition);
      //Debug.Log($"Click pos={clickPosition}; worldPoint={worldPoint}");
      _fluxyTarget.transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
      ClicksCount += ClicksInOneClick;

      _fluxyTarget.color = _clickColor.GetClickColor();
      Splat().Forget();
    }


    private async UniTaskVoid Splat()
    {
      _fluxyTarget.gameObject.SetActive(true);
      await UniTask.WaitForEndOfFrame(destroyCancellationToken);
      _fluxyTarget.gameObject.SetActive(false);
    }
  }
}