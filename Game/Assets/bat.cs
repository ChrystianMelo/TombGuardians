using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public float speed = 1.5f;
    private Transform jogador;
    private PlayerController player;
    private float atktime = 0;
    // Start is called before the first frame update
    void Start()
    {
        getTarget(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health.IsAlive)
        {
            if(Vector3.Distance(transform.position, jogador.position) > 1.5)
            {
                transform.position = Vector3.MoveTowards(transform.position, jogador.position, speed * Time.deltaTime);
            } else
            {
                atktime += Time.deltaTime;
                if(atktime >= 1f)
                {
                    player.health.takeDamage(4);
                    atktime = 0;
                }    
            }
            
        } else
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
}
