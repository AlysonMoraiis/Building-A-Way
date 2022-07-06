using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private GameObject _creditsScreen;

    private void Awake()
    {
        _playButton.onClick.AddListener(HandlePlayButton);
        _creditsButton.onClick.AddListener(HandleCreditsButton);
        _exitButton.onClick.AddListener(HandleExitButton);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(HandlePlayButton);
        _creditsButton.onClick.RemoveListener(HandleCreditsButton);
        _exitButton.onClick.RemoveListener(HandleExitButton);
    }

    private void HandlePlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void HandleCreditsButton()
    {
        _creditsScreen.SetActive(true);
    }

    private void HandleExitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
