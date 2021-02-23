using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpForce = 2.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private bool _facingRight = true;
    private bool _isGrounded;


    //Movimiento
    private Vector2 _movement;

    //Attack
    private bool _isAttacking;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        if (_isAttacking == false)
        {
            // movimiento
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(horizontalInput, 0f);

            // voltear personaje
            if (horizontalInput < 0f && _facingRight == true)
            {
                Flip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                Flip();
            }
        }

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }

    private void FixedUpdate()
    {
        //if (_isAttacking == false)
       // {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
      //  }


    }
    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
        
        // Animator
        // 0 por que es la base layer
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Atack"))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;
        }
    }

        private void Flip()
          {
        _facingRight = !_facingRight;

        float localScalex = transform.localScale.x;
        localScalex = localScalex * -1f;
        transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);

    }

}
