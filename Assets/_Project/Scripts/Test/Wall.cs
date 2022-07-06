using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject _stair;

    private bool _canAcrescent;

    void Start()
    {
        _canAcrescent = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (PlayerInstantiate.Instance._isPaused == false && Input.GetKeyUp(KeyCode.E))
        {
            _canAcrescent = false;
            Time.timeScale = 1;
        }

        if (_canAcrescent)
        {
            _stair.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 2f * Time.unscaledDeltaTime, transform.localScale.z);
        }
    }
}
