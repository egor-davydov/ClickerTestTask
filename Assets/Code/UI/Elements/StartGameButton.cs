using UnityEngine.SceneManagement;

namespace Code.UI.Elements
{
  public class StartGameButton : ButtonHandler
  {
    public override void OnClick()
    {
      SceneManager.LoadSceneAsync("Main");
    }
  }
}