using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _pauseBackground;
    [SerializeField] private PlayerInstantiate _playerInstantiate;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(HandlePauseButton);
        _resumeButton.onClick.AddListener(HandlePauseButton);
        _quitButton.onClick.AddListener(HandleQuitButton);
        _menuButton.onClick.AddListener(HandleMenuButton);
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveListener(HandlePauseButton);
        _resumeButton.onClick.RemoveListener(HandlePauseButton);
        _quitButton.onClick.RemoveListener(HandleQuitButton);
        _menuButton.onClick.RemoveListener(HandleMenuButton);
    }

    public void HandlePauseButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            _pauseBackground.SetActive(true);
            _playerInstantiate._isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            _pauseBackground.SetActive(false);
            _playerInstantiate._isPaused = false;
        }
    }

    public void HandleQuitButton()
    {
        Application.Quit();
    }

    public void HandleMenuButton()
    {
        PlayerInstantiate.Instance._isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
