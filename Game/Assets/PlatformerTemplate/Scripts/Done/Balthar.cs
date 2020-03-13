using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balthar : MonoBehaviour
{
    public GameObject ShootPoint;
    public GameObject BombPoint;
    private int player;
    public GameObject bullet;
    public GameObject bomb;
    public float reloadTime = 0.1f;
    public float bombTime = 1f;
    private float lastShot = 0;
    private float lastBomb = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>().playerID;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player == 1 && Input.GetButton("Fire1")) || (player == 2 && Input.GetButton("Fire(S)")))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        float tempo = Time.time;
        int shot = Random.Range(1, 2);
        if (tempo >= lastShot + reloadTime)
        {
            lastShot = tempo;
            projetil tiro = Instantiate(bullet, ShootPoint.transform.position, ShootPoint.transform.rotation).GetComponent<projetil>();
            tiro.damage = 10;
        }
        if (tempo >= lastBomb + bombTime)
        {
            lastBomb = tempo;
            Instantiate(bomb, BombPoint.transform.position, BombPoint.transform.rotation);
        }
        
    }
}
