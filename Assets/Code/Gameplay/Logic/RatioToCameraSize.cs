using Code.Gameplay.Logic.Anchors;
using UnityEngine;

namespace Code.Gameplay.Logic
{
  public class RatioToCameraSize : MonoBehaviour
  {
      [SerializeField] private Camera _camera;
      [SerializeField] private float _boundsSizeX = 1.3f;
      [SerializeField] private float _boundsSizeY = 2.8f;

      private void Awake()
      {
        OrientationCheck.OnOrientationChange += ChangeCameraSize;
        ChangeCameraSize(Screen.orientation);
      }

      private void ChangeCameraSize(ScreenOrientation screenOrientation)
      {
        float screenRatio = Screen.width / (float)Screen.height;
        float targetRatio = _boundsSizeX / _boundsSizeY;

        if (screenRatio >= targetRatio)
        {
          _camera.orthographicSize = _boundsSizeY / 2;
        }
        else
        {
          float differenceInSize = targetRatio / screenRatio;
          _camera.orthographicSize = _boundsSizeY / 2 * differenceInSize;
        }
      }
  }
}