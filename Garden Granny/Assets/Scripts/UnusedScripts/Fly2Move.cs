using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly2Move : MonoBehaviour
{
    public float speed;
    public GameObject target;
    private GameObject[] crops;
    int index;
    public int targetRadius;
    public GameObject fly;

    public GameObject gameManager;
    public GameManager gameManagerScript;

    public Health health;


    void Start()
    {
        crops = GameObject.FindGameObjectsWithTag("Crop");
        index = Random.Range(0, crops.Length);
        target = crops[index];
        fly = this.gameObject;

        this.gameObject.SetActive(true);

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        health = this.GetComponent<Health>();
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

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    
}
