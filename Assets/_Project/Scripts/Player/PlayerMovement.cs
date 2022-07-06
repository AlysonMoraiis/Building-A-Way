using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _moveSpeed;
    [SerializeField] private Transform _wallPoint;
    [SerializeField] private Transform _groundPoint;

    [Header("Layers")]
    [SerializeField] private LayerMask _wallLayerMask;
    [SerializeField] private LayerMask _groundLayerMask;

    [Header("Others")]

    private bool _isFacingRight = true;
    public bool _canMove = true;

    void Update()
    {
        WallCheck();
        GroundCheck();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0f, _rigidbody2D.velocity.y);
        }
    }

    private void Flip()
    {
        if (_isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            _moveSpeed = -2;
        }

        else
        {
            _isFacingRight = !_isFacingRight;
            _moveSpeed = 2;
        }

        transform.Rotate(0, 180, 0);
    }

    private void WallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(_wallPoint.position, transform.TransformDirection(Vector2.right), 0.1f, _wallLayerMask);

        if (hit)
        {
            Flip();
        }
    }

    public bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundPoint.position, transform.TransformDirection(Vector2.down), 0.1f, _groundLayerMask);

        if (hit)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
