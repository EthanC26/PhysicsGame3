using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : BaseMenu
{
    public Button playBtn;
    public Button creditsBtn;
    public Button SettingsBtn;
    public Button quitBtn;

    public TMP_Text Title;

    public override void Init(MenuController contex)
    {
        base.Init(contex);
        state = MenuStates.MainMenu;
        if (playBtn) playBtn.onClick.AddListener(() => SceneManager.LoadScene("Level"));
        if (creditsBtn) creditsBtn.onClick.AddListener(() => SetNextMenu(MenuStates.Credits));
        if(SettingsBtn) SettingsBtn.onClick.AddListener(() => SetNextMenu(MenuStates.Settings));
        if (quitBtn) quitBtn.onClick.AddListener(QuitGame);

        Title.text = "Fin Run";
    }
}