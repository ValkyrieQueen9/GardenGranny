using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.currentHealth = healthComponent.maxHealth;

                this.gameObject.SetActive(false);
            }

        }
    }
}
