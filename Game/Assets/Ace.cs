using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ace : MonoBehaviour
{
    public GameObject ShootPoint;
    private PlayerController jogador;
    private int player;
    public GameObject SoundWave;
    public float reloadTime = 0.15f;
    private float lastShot = 0;
    public float heal = 5f;
    private float healTimer;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GetComponent<PlayerController>();
        player = jogador.playerID;
        healTimer = 0f;
        heal = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player == 1 && Input.GetButton("Fire1")) || (player == 2 && Input.GetButton("Fire(S)")))
        {
            Shoot();
        }

        healTimer += Time.deltaTime;
        if(healTimer >= 1.5f)
        {
            jogador.health.takeDamage(-10);
            healTimer = 0f;
        }
        
    }

    void Shoot()
    {
        float tempo = Time.time;
        if (tempo >= lastShot + reloadTime)
        {
            lastShot = tempo;
            Instantiate(SoundWave, ShootPoint.transform.position, ShootPoint.transform.rotation);
        }
    }
}
