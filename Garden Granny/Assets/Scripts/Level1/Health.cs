 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Animator enemyAnimation;
    public Animator playerAnimation;

    private PlayerMovement movement;
    private GameObject player;
    private PlayerAttack playerAttack;
    private Score scoreScript;

    private int runOnce = 0;

    void Start()
    {
        //Gathering player info
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<PlayerMovement>();
        playerAnimation = player.GetComponent<Animator>();
        playerAttack = player.GetComponent<PlayerAttack>();

        currentHealth = maxHealth;

        scoreScript = FindObjectOfType<Score>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        //Crop Death
        if (currentHealth <= 0 & gameObject.tag == "Crop")
        {
            CropDie();
            scoreScript.cropsKilled++;
        }

        //Enemy Death
        if (currentHealth <= 0 & gameObject.tag == "Enemy" & runOnce ==0)
        {
            EnemyDie();
            scoreScript.enemiesKilled++;
            runOnce++;
        }

        //Player Stun
        if (currentHealth <= 0 & gameObject.tag == "Player")
        {
            StartCoroutine(PlayerStun());
        }
    }

    //Enemy Death Animation and destruction
    public void EnemyDie()
    {
        enemyAnimation.SetBool("Death", true);
        Destroy(this.gameObject, 1.0f);
    }

    //Crop Death and destruction
    public void CropDie()
    {
        this.gameObject.SetActive(false);
    }

    IEnumerator PlayerStun()
    {
        movement.enabled = false;
        playerAnimation.enabled = false;
        playerAttack.enabled = false;
        yield return new WaitForSeconds(2.0f);
        movement.enabled = true;
        playerAnimation.enabled = true;
        playerAttack.enabled = true;
        currentHealth = maxHealth;
    }
}


