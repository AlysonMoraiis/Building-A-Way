using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public bool _isDead;

    private void Start()
    {
        _isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerDeath();
        }
    }

    void Update()
    {

    }

    private void PlayerDeath()
    {
        _isDead = true;
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
