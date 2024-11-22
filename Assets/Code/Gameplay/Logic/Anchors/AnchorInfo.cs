using System;
using UnityEngine;

namespace Code.Gameplay.Logic.Anchors
{
  [Serializable]
  public struct AnchorInfo
  {
    [field: SerializeField] public ScreenOrientation[] ScreenOrientations { get; private set; }
    [field: SerializeField] public Vector2 AnchorMin { get; private set; }
    [field: SerializeField] public Vector2 AnchorMax { get; private set; }
  }
}