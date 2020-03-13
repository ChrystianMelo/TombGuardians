using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anny : MonoBehaviour
{
    public GameObject ShootPoint;
    private int player;
    public GameObject ball;
    public float reloadTime = 0.75f;
    private float lastShot = 0;

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
        if (tempo >= lastShot + reloadTime)
        {
            lastShot = tempo;
            Instantiate(ball, ShootPoint.transform.position, ShootPoint.transform.rotation);
        }
    }
}