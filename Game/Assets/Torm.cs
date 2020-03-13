using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torm : MonoBehaviour
{

    public Transform wind;
    public Transform[] moveSpots = new Transform[2];
    int goingTo;
    float speed = 2.5f;
    public Transform[] WindSpots;
    public Transform[] LightningSpots;
    public GameObject Whirlwind;
    public GameObject Lightning;
    float AtkTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        goingTo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        wind.Rotate(0f, 0f, 2.5f);
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[goingTo].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[goingTo].position) <= 0.2f)
        {
            goingTo = (goingTo + 1) % 2;
        }

        AtkTimer += Time.deltaTime;
        if(AtkTimer >= 1f) {

            int c = 1;
            while(c <= 8)
            {
                int atk = Random.Range(1, 3);
                switch(atk)
                {
                    case 1: Instantiate(Lightning, LightningSpots[Random.Range(0, LightningSpots.Length)].position, Quaternion.identity);
                        break;
                    case 2: Instantiate(Whirlwind, WindSpots[Random.Range(0, WindSpots.Length)].position, Quaternion.identity);
                        break;
                }
                c++;
            }
            AtkTimer = 0f;
        }
    }
}
