using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip DeathClip;

    private static GameManager instance;
    public static GameManager Instance => instance;

    private Transform currentCheckPoint;

    #region PLAYER CONTROLLER INFO
    [SerializeField] private PlayerController playerPrefab;
    private PlayerController _playerInstance;
    public PlayerController PlayerInstance => _playerInstance;

    public event Action<PlayerController> OnPlayerSpawned;
    #endregion

    #region Lives
    public event Action<int> OnLifeValueChanged;
    [SerializeField] private int maxLives = 3;
    private int _lives = 3;

    public int lives//player Lives
    {
        get => _lives;
        set
        {
            if (value < 0)
            {
                audioSource.PlayOneShot(DeathClip);
                GameOver();
                return;
            }
            if (_lives > value)
            {
                audioSource.PlayOneShot(DeathClip);
                Respawn();
            }
            _lives = value;

            if (_lives > maxLives) _lives = maxLives;

            OnLifeValueChanged?.Invoke(_lives);

        }
    }
    #endregion

    private MenuController CurrentMenuController;

    public void SetMenuController(MenuController controller) => CurrentMenuController = controller;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
            return;
        }
        Destroy(gameObject);
    }

    public void InstantiatePlayer(Transform spawnLocation)//spawn player
    {
        _playerInstance = Instantiate(playerPrefab,spawnLocation.position,Quaternion.identity);
        currentCheckPoint = spawnLocation;
        OnPlayerSpawned?.Invoke(_playerInstance);
    }

    public void Respawn()//respawn player
    {
        _playerInstance.transform.position = currentCheckPoint.position;
    }

    public void GameOver()//end game
    {
            string sceneName = (SceneManager.GetActiveScene().name.Contains("Level")) ? "GameOver" : "Level";
            SceneManager.LoadScene(sceneName);
            CurrentMenuController.SetActiveState(MenuStates.GameOver);
    }

}
