using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _finishScreen.SetActive(true);
            PlayerInstantiate.Instance._isPaused =true ;
            Time.timeScale = 0;
        }
    }
}
