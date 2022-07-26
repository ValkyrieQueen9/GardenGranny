using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{

    //fly movement
    public float speed;
    private GameObject target;
    private GameObject[] crops;
    private int index;

    //fly attacks
    public int distance;
    public int damage;
    private Health health;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    

    void Start()
    {
        //fly targeting
        crops = GameObject.FindGameObjectsWithTag("Crop");
        index = Random.Range(0, crops.Length);
        target = crops[index];

        this.gameObject.SetActive(true);

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        health = this.GetComponent<Health>();

        Application.targetFrameRate = 30;
    }

    void Update()
    {
        //destroys enemy when game is over
        if (gameManagerScript.gameFail == true)
        {
            health.EnemyDie();
        }

        //Keeps fly moving by continously finding new target
        if (target.gameObject.activeSelf == false & gameManagerScript.gameFail == false)
        {
            index = Random.Range(0, crops.Length);
            target = crops[index];
            return;
        }

        //moves fly
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        //Stops the fly from damaging crops while moving.
        if (Vector3.Distance(target.transform.position, this.transform.position) < distance)
        {
            var healthComponent = target.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage);
            }
        }
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


}
