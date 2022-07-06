using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreenBackground : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerInstantiate.Instance._isPaused == false)
        {
            Time.timeScale = 0;
            PlayerInstantiate.Instance._isPaused = true;
        }
    }

    private void OnDisable()
    {
        if (PlayerInstantiate.Instance._isPaused == true)
        {
            Time.timeScale = 1;
            PlayerInstantiate.Instance._isPaused = false;
        }
    }
}