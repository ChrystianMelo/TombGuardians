using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    public float speed = 1.5f;
    private Transform jogador;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        getTarget();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health.IsAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, jogador.position, speed * Time.deltaTime);
        }
        else
        {
            getTarget();
        }
    }

    void getTarget()
    {
        GameObject[] jogadores = GameObject.FindGameObjectsWithTag("Player");
        int alvo = Random.Range(0, jogadores.Length);

        player = jogadores[alvo].GetComponent<PlayerController>();
        jogador = jogadores[alvo].GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController vida = collision.GetComponent<PlayerController>();

        if (vida)
        {
            vida.health.takeDamage(10);
            Guillo.hp.takeDamage(-10);
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

