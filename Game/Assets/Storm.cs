using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{
    bool changeSize = true;
    float tamanho;
    // Start is called before the first frame update
    void Start()
    {
        tamanho = transform.lossyScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 2.5f);
        if(changeSize)
        {
            tamanho += 0.01f;
            transform.localScale = new Vector3(tamanho, tamanho, transform.localScale.z);
            if(tamanho >= 0.2f)
            {
                changeSize = false;
            }
        } else
        {
            tamanho -= 0.01f;
            transform.localScale = new Vector3(tamanho, tamanho, transform.localScale.z);
            if (tamanho <= 0.005f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet")) {

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController jogador = collision.GetComponent<PlayerController>();
        if(jogador) {

            jogador.health.takeDamage(1);
        }
    }
}
