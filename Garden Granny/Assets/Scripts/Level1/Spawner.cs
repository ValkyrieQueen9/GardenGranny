using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public GameObject chosenHealth;
    public Health playerHealth;
    public bool anyActive = false;

    private int index;

    void Start()
    {
        chosenHealth = powerUps[0];
    }

    private void Update()
    {
        //enable randomised PowerUp if health is below half 
        if (playerHealth.currentHealth <= playerHealth.maxHealth / 2 & anyActive == false)
        {
            index = Random.Range(0, powerUps.Length);
            chosenHealth = powerUps[index];
            ReEnableObject(chosenHealth);
        }

        //sets chosen health when destroyed
        if (chosenHealth == null)
        {
            chosenHealth = powerUps[0];
        }

        //checks if any PowerUps are currently active
        if (playerHealth.currentHealth >= playerHealth.maxHealth / 2)
        {
            foreach (GameObject p in powerUps)
            {
                if(powerUps[0].activeInHierarchy == false & powerUps[1].activeInHierarchy == false & powerUps[2].activeInHierarchy == false & powerUps[3].activeInHierarchy == false)
                {
                    anyActive = false;
                }
                else
                {
                    anyActive = true;
                }
            }
        }
    }

    //Enables PowerUp 
    void ReEnableObject(GameObject chosenHealth)
    {
        chosenHealth.SetActive(true);
        anyActive = true;
        return;
    }
}
