using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    public float speed = 1f;
    private GameObject tomb;
    private float atktime = 0;
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
            if (Vector3.Distance(transform.position, tomb.transform.position) > 1.5)
            {
                transform.position = Vector3.MoveTowards(transform.position, tomb.transform.position, speed * Time.deltaTime);
            }
            else
            {
                atktime += Time.deltaTime;
                if (atktime >= 1f)
                {
                    tomb.GetComponent<Tomb>().takeDamage(10);
                    atktime = 0;
                }
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
