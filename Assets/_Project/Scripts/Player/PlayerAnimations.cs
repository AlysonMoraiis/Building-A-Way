using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private LadderMovement _ladderMovement;
    [SerializeField] private PlayerCollision _playerCollision;

    void Update()
    {
        if (_rigidBody2D.velocity.y < 0)
        {
            _animator.SetBool("IsFall", true);
        }

        if (_ladderMovement._isClimbing)
        {
            _animator.SetBool("IsClimbing", true);
        }
        else
        {
            _animator.SetBool("IsClimbing", false);
        }

        if (_playerCollision._isDead)
        {
            _animator.SetTrigger("Death");
        }

        if (PlayerInstantiate.Instance._isThinking)
        {
            _animator.SetBool("IsThinking", true);
            _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        else
        {
            _animator.SetBool("IsThinking", false);
            _animator.updateMode = AnimatorUpdateMode.Normal;
        }
    }
}
