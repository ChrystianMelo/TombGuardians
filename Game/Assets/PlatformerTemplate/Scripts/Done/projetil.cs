using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{

    public float speed = 1f;
    public int damage = 25;
    public Rigidbody2D bala;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        Vector3 posicao = transform.position;
        Vector3 frente = transform.right;
        Vector3 movimento = frente * speed;

        transform.position = posicao + movimento;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController atingido = collision.GetComponent<EnemyController>();
        if(atingido)
        {
            atingido.takeDamage(damage);
            Destroy(this.gameObject);
        }

        BossHealth chefe = collision.GetComponent<BossHealth>();
        if (chefe)
        {
            chefe.takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
