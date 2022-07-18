 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Animator animator;
    public Animator playerAnimation;
    private SpriteRenderer SpriteColor;
    private PlayerMovement movement;
    private GameObject player;
    private PlayerAttack playerAttack;

    private Score scoreScript;
    private GameObject scoreObject;

    private int runOnce = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<PlayerMovement>();
        playerAnimation = player.GetComponent<Animator>();
        playerAttack = player.GetComponent<PlayerAttack>();

        currentHealth = maxHealth;
        //SpriteColor = this.GetComponent<SpriteRenderer>();
        scoreScript = FindObjectOfType<Score>();
    }

    //Damage and death check
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0 & gameObject.tag == "Crop")
        {
            CropDie();
            scoreScript.cropsKilled++;
        }

        if (currentHealth <= 0 & gameObject.tag == "Enemy" & runOnce ==0)
        {
            EnemyDie();
            scoreScript.enemiesKilled++;
            runOnce++;

            /* FlyDeath Sound! - Didn't like it
            if (FindObjectOfType<AudioManager>().IsThisSoundPlaying(1))
            {
                FindObjectOfType<AudioManager>().Play("FlyDeath");
            }
            */
        }

        if (currentHealth <= 0 & gameObject.tag == "Player")
        {
            StartCoroutine(PlayerStun());
        }

    }

    //Enemy Death Animation and destruction
    public void EnemyDie()
    {
        animator.SetBool("Death", true);
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
        yield return new WaitForSeconds(3.0f);
        movement.enabled = true;
        playerAnimation.enabled = true;
        playerAttack.enabled = true;
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}


