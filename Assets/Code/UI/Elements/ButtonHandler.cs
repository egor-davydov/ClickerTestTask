using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
  public abstract class ButtonHandler : MonoBehaviour
  {
    [field: SerializeField] public Button Button { get; private set; }

    private void Awake()
    {
      Button.onClick.AddListener(OnClick);
    }

    public abstract void OnClick();
  }
}