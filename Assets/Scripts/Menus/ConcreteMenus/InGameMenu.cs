using TMPro;
using UnityEngine.UI;

public class InGameMenu : BaseMenu
{
    public TMP_Text livesText;
    public Button pauseBtn;
    public override void Init(MenuController context)
    {
        base.Init(context);
        state = MenuStates.InGame;

        if(pauseBtn) pauseBtn.onClick.AddListener(() => SetNextMenu(MenuStates.Pause));
        livesText.text = $"Lives: {GameManager.Instance.lives + 1}";

        GameManager.Instance.OnLifeValueChanged += LifeValueChanged;

    }

    private void LifeValueChanged(int Value) => livesText.text = $"Lives: {Value + 1}";

    private void OnDestroy() => GameManager.Instance.OnLifeValueChanged -= LifeValueChanged;

}
