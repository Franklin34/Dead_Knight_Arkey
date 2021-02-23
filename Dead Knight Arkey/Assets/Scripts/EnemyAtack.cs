using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || gameObject.GetComponentInChildren<BoxCollider2D>().tag != "vision")
        {
            //gameObject.GetComponentInChildren<BoxCollider2D>().tag;
            Debug.Log("entre");
            collision.SendMessageUpwards("AddDamage", 10);
        }
    }
}
