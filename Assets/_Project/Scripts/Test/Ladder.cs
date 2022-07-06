using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private GameObject _ladder;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _canAcrescent;


    void Start()
    {
        _canAcrescent = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (_spriteRenderer.size.y <= 2f && _canAcrescent == false)
        {
            Destroy(gameObject);
        }

        if (PlayerInstantiate.Instance._isPaused == false && Input.GetKeyUp(KeyCode.Q))
        {
            _canAcrescent = false;
            PlayerInstantiate.Instance._isThinking = false;
            Time.timeScale = 1;
        }

        if (_canAcrescent)
        {
            if (_spriteRenderer.size.y >= 7.25f)
            {
                _canAcrescent = false;
                return;
            }
            _spriteRenderer.size += new Vector2(0, 4.5f * Time.unscaledDeltaTime);
        }
    }
}
