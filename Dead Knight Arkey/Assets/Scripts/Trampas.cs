using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    public int healthdamage = 1;



    private void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("AddDamage", healthdamage);
        }
    }

}
