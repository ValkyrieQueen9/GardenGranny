using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly2hit : MonoBehaviour
{
    public GameObject flyTarget;
    public int distance;
    public int damage;

    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    //Player takes damage if fly collides with them.
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

    //Stops the bug from damaging crops while moving.
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
