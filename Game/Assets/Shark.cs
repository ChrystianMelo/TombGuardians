using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public GameObject bala;
    public GameObject metralhadora;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
       if(this.gameObject.transform.position.x > 6)
        {
            this.gameObject.transform.Rotate(0f, 180f, 0f);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= 2.5f)
        {
            
            Instantiate(bala, metralhadora.transform.position, metralhadora.transform.rotation);
            timer = 0;
        }

        if(transform.position.y > 15)
        {
            Destroy(this.gameObject);
            EnemyManager.contador--;
        }
    }
}
