using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    //public bool readyToSpawn;

    public GameObject player;
    public Health playerHealth;

    public GameObject[] powerUps;

    public GameObject chosenHealth;

    private int index;

    public bool anyActive = false;

    private int runOnce;

    void Start()
    {
        chosenHealth = powerUps[0];
        playerHealth = player.GetComponent<Health>();
    }

    private void Update()
    {
        //enable if conditions are met
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

        //checks if any are active
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

    void ReEnableObject(GameObject chosenHealth)
    {
                chosenHealth.SetActive(true);
                anyActive = true;
                return;
    }
}
