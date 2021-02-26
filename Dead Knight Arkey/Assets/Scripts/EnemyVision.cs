using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float visionRadiuss;
    public float speed;

    private EnemyPatrol1 patrol;

    Vector3 initialPosition;

    GameObject player;

    private void Awake()
    {
        patrol = GetComponent<EnemyPatrol1>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tarjet = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadiuss) tarjet = player.transform.position;

        if(player.transform.position.x - transform.position.x < 0){
            transform.localScale = new Vector3(-1,1,1);
            patrol._facingRight = false;
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
            patrol._facingRight = true;
        }

        float fixedspeed = 1 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, tarjet, fixedspeed);

        Debug.DrawLine(transform.position, tarjet, Color.green);

    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, visionRadiuss);
    }*/
}
