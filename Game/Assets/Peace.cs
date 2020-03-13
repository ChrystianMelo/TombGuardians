using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peace : MonoBehaviour
{

    public GameObject estacaDeGelo;
    public GameObject shark;
    public Transform[] IceShots;
    public Transform[] SharkSpawns;
    float AtkTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        int atk = Random.Range(0, 3);
        if (atk == 1)
        {
            int c = 0;
            int iceSpot;
            while (c < 4)
            {
                iceSpot = Random.Range(0, IceShots.Length);
                Instantiate(estacaDeGelo, IceShots[iceSpot].position, IceShots[iceSpot].rotation);
                c++;
            }
        }
        else if (atk == 2)
        {
            Instantiate(shark, SharkSpawns[0].position, Quaternion.identity);
            Instantiate(shark, SharkSpawns[1].position, Quaternion.identity);
            EnemyManager.contador += 2;
        }
        AtkTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        AtkTimer += Time.deltaTime;
        if(AtkTimer >= 2f)
        {
            int atk = Random.Range(0, 3);
            if(atk == 1)
            {
                int c = 0;
                int iceSpot;
                while(c < 4)
                {
                    iceSpot = Random.Range(0, IceShots.Length);
                    Instantiate(estacaDeGelo, IceShots[iceSpot].position, IceShots[iceSpot].rotation);
                    c++;
                }
            } else if(atk == 2)
            {
                Instantiate(shark, SharkSpawns[0].position, Quaternion.identity);
                Instantiate(shark, SharkSpawns[1].position, Quaternion.identity);
                EnemyManager.contador += 2;
            }
            AtkTimer = 0;
        }
    }
}
