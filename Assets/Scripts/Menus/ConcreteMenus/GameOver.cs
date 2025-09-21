using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : BaseMenu
{
    public Button MainMenuBtn;
    public Button QuitBtn;

    public TMP_Text Title;

    public override void Init(MenuController context)
    {
        base.Init(context);
        state = MenuStates.GameOver;

        if (MainMenuBtn) MainMenuBtn.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        if (QuitBtn) QuitBtn.onClick.AddListener(QuitGame);

        if (GameManager.Instance.lives <= 0)
            Title.text = "Game Over!\nYou Died!";
        else if (GameManager.Instance.lives > 0)
            Title.text = "Game Over!\nYou Win!";
    }
}