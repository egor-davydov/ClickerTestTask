using System;
using UnityEngine;

namespace Code.Gameplay.Logic.Anchors
{
  [Serializable]
  public struct ElementInfo
  {
    [field: SerializeField] public RectTransform RectTransform { get; private set; }
    [field: SerializeField] public AnchorInfo[] AnchorInfos { get; private set; }
  }
}