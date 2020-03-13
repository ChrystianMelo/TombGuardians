using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBomb : MonoBehaviour
{
    public float speed = 1f;
    private GameObject tomb;
    
    // Start is called before the first frame update
    void Start()
    {
        getTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (tomb.GetComponent<Tomb>().currentHP > 0)
        {
            if (Vector3.Distance(transform.position, tomb.transform.position) > 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, tomb.transform.position, speed * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
                tomb.GetComponent<Tomb>().takeDamage(100);
                EnemyManager.contador--;
            }

        }
        else
        {
            getTarget();
        }
    }

    void getTarget()
    {
        tomb = GameObject.FindGameObjectWithTag("Tomb");
    }
}
