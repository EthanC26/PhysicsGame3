using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    //Expression Body Syntax for Functuons that can be one line of code
    void Start()
    {
        if(GameManager.Instance.lives != 3)
        {
            GameManager.Instance.lives = 3;
        }
        GameManager.Instance.InstantiatePlayer(startPos);
    }
}
