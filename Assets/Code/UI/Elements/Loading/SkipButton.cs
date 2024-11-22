using UnityEngine.SceneManagement;

namespace Code.UI.Elements.Loading
{
  public class SkipButton : ButtonHandler
  {
    public override void OnClick()
    {
      SceneManager.LoadSceneAsync("Menu");
    }
  }
}