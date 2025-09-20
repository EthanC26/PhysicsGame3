using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryMenu : BaseMenu
{
    public Button MainMenuBtn;
    public Button QuitBtn;

    public TMP_Text Title;

    public override void Init(MenuController context)
    {
        base.Init(context);
        state = MenuStates.Victory;

        if(MainMenuBtn) MainMenuBtn.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        if(QuitBtn) QuitBtn.onClick.AddListener(QuitGame);

        Title.text = "Game Over!\nYou Win!";
    }
}
