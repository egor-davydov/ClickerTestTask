using System.Linq;
using UnityEngine;

namespace Code.Gameplay.Logic.Anchors
{
  public class OrientationToAnchors : MonoBehaviour
  {
    [SerializeField] private ElementInfo[] _elementInfos;

    private void Awake()
    {
      OrientationCheck.OnOrientationChange += ChangeElementsAccordingToOrientation;
      ChangeElementsAccordingToOrientation(Screen.orientation);
    }

    private void ChangeElementsAccordingToOrientation(ScreenOrientation currentOrientation)
    {
      foreach (ElementInfo elementInfo in _elementInfos)
      {
        AnchorInfo anchorInfo = elementInfo.AnchorInfos.First(x=>x.ScreenOrientations.Contains(currentOrientation));
        elementInfo.RectTransform.anchorMin = anchorInfo.AnchorMin;
        elementInfo.RectTransform.anchorMax = anchorInfo.AnchorMax;
      }
    }
  }
}