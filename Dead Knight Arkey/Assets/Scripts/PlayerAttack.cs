using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool _isAttacking;
    private Animator _animator;
    private Transform _transform;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        _boxCollider2D = GetComponentInChildren<BoxCollider2D>();

    }
    private void LateUpdate()
    {
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Atack"))
        {
           
            _isAttacking = true;

        }
        else
        {
          
            _isAttacking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAttacking == true)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.SendMessageUpwards("AddDamage");
            }
        }
    }
}
