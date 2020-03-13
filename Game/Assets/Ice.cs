using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{

    public float speed = 0.5f;
    public int damage = 30;


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
        PlayerController atingido = collision.GetComponent<PlayerController>();
        if (atingido)
        {
            atingido.health.takeDamage(damage);
        }

    }
}
