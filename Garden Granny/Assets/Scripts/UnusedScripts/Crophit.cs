using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crophit : MonoBehaviour
{
    public int currentCropHp = 0;
    public int maxCropHp = 20;


    void Start()
    {
        currentCropHp = maxCropHp;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            currentCropHp -= 1;
        }
    }


    void Update()
    {
        if (currentCropHp == 0)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }
}
