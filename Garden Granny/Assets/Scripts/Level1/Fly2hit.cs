using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly2hit : MonoBehaviour
{
    private Collider2D collision;
    private bool IsMoving2;
    public GameObject flyTarget;
    public int distance;
    private Collider2D targetCollider;
    public int damage;


    private void Start()
    {
        Application.targetFrameRate = 30;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(2);
            }
        }
    }


    // TRYING TO STOP THE BUG FROM HITTING WHILE MOVING
    private void Update()
    {
        flyTarget = GetComponent<Fly2Move>().target;


    if (Vector3.Distance(flyTarget.transform.position, this.transform.position) < distance)
            {
                var healthComponent = flyTarget.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(damage);
                }
            }
    }
    
    }
