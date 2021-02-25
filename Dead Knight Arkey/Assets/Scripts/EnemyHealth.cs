using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 3;
    public float death = 0.5f;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AddDamage()
    {
        health = health - 1;

        _animator.SetTrigger("TakeHit");

        if(health == 0)
        {
            StartCoroutine("Death");
           
        }

    }
    private IEnumerator Death()
    {
        _animator.SetTrigger("Death");

        yield return new WaitForSeconds(death);

        gameObject.SetActive(false);
    }
}
