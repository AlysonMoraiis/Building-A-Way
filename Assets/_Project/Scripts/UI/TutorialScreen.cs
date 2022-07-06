using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] private GameObject _background;

    void Start()
    {
        if (PlayerPrefs.GetInt("TutorialScreen") == 0)
        {
            _background.SetActive(true);
            PlayerPrefs.SetInt("TutorialScreen", 1);
        }
    }

    void Update()
    {

    }
}
