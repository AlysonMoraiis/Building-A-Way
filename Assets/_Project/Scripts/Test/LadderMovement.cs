using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _verticalSpeed = 8f;
    private bool _ladder;
    public bool _isClimbing;

    void Update()
    {
        if (_ladder)
        {
            _isClimbing = true;
            _playerMovement._canMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isClimbing)
        {
            _rigidbody2D.gravityScale = 0f;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _verticalSpeed);
        }
        else
        {
            _rigidbody2D.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _ladder = true;
            _playerTransform.transform.position = new Vector3(other.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _ladder = false;
            _isClimbing = false;
            Destroy(other.gameObject);
            _playerMovement._canMove = true;
        }
    }
}
