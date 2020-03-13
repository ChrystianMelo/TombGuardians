using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viper : MonoBehaviour
{
    public GameObject ShootPoint;
    private int player;
    public GameObject bullet;
    public float reloadTime = 0.1f;
    private float lastShot = 0;
    private PlayerController vida;
    private bool Ghost;
    private Renderer visual;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>().playerID;
        vida = GetComponent<PlayerController>();
        Ghost = false;
        visual = GetComponent<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((player == 1 && Input.GetButton("Fire1")) || (player == 2 && Input.GetButton("Fire(S)")))
        {
            Shoot();
        }

        if (vida.health.hurt)
        {
            StartCoroutine(GhostForm());
        }
    }

    void Shoot()
    {
        float tempo = Time.time;
        if (tempo >= lastShot + reloadTime && !Ghost)
        {
            lastShot = tempo;
            projetil tiro = Instantiate(bullet, ShootPoint.transform.position, ShootPoint.transform.rotation).GetComponent<projetil>();
            tiro.damage = 50;
        }
    }

    IEnumerator GhostForm()
    {
        vida.maxSpeed = 7;
        vida.health.attainable = false;
        Ghost = true;
        visual.material.SetColor("_Color", new Color(0f, 0f, 0f, 0.25f));

        yield return new WaitForSeconds(3f);

        vida.health.attainable = true;
        vida.maxSpeed = 3;
        Ghost = false;
        visual.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
    }
}
