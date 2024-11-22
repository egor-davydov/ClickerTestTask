using System.Collections.Generic;
using Code.Extensions;
using UnityEngine;

namespace Code.Gameplay.Click
{
  public class ClickColor : MonoBehaviour
  {
    [SerializeField] private int _numberUnrepeatedColors = 1;
    [SerializeField] private float _similarEpsilon = 0.1f;

    private Queue<Color> _previousColors;

    private void Awake()
    {
      _previousColors = new Queue<Color>(_numberUnrepeatedColors);
    }

    public Color GetClickColor()
    {
      Color randomizedColor;
      do
      {
        randomizedColor = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
        );
      } while (IsSimilarToPrevious(randomizedColor));

      SetPreviousColor(randomizedColor);
      return randomizedColor;
    }

    private void SetPreviousColor(Color color)
    {
      if (_previousColors.Count == _numberUnrepeatedColors)
        _previousColors.Dequeue();
      _previousColors.Enqueue(color);
    }

    private bool IsSimilarToPrevious(Color color)
    {
      foreach (Color previousColor in _previousColors)
      {
        if (color.SimilarTo(previousColor, _similarEpsilon))
          return true;
      }

      return false;
    }
  }
}