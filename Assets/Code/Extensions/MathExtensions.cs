using UnityEngine;

namespace Code.Extensions
{
  public static class MathExtensions
  {
    private const float DefaultEpsilon = 0.1f;

    public static bool SimilarTo(this Vector4 vector1, Vector4 vector2, float epsilon = DefaultEpsilon) =>
      VectorsSimilar(vector1, vector2, epsilon);

    public static bool SimilarTo(this Color color1, Vector4 color2, float epsilon = DefaultEpsilon) =>
      VectorsSimilar(color1, color2, epsilon);

    private static bool VectorsSimilar(Vector4 vector1, Vector4 vector2, float epsilon = DefaultEpsilon)
    {
      Vector4 absDelta = Abs(vector1 - vector2);
      return absDelta.x < epsilon && absDelta.y < epsilon && absDelta.z < epsilon && absDelta.w < epsilon;
    }

    private static Vector4 Abs(Vector4 delta)
    {
      var absColor = new Vector4(Mathf.Abs(delta.x), Mathf.Abs(delta.y), Mathf.Abs(delta.z), Mathf.Abs(delta.w));
      return absColor;
    }
  }
}