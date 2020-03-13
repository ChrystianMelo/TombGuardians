using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guillo : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] Shadows;
    public GameObject Shadow_ball;
    public float timer;
    public float TimeBetweenAtks = 5f;
    public Transform[] MoveSpots;
    public static BossHealth hp;

    int pontoAleat;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        pontoAleat = Random.Range(0, MoveSpots.Length);
        hp = GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= TimeBetweenAtks)
        {
            int c = 0;
            while(c < Shadows.Length)
            {
                Instantiate(Shadow_ball, Shadows[c].position, Quaternion.identity);
                c++;
            }
            timer = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, MoveSpots[pontoAleat].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, MoveSpots[pontoAleat].position) <= 0.2f)
        {
            pontoAleat = Random.Range(0, MoveSpots.Length);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerHp = collision.GetComponent<PlayerController>();
        if(playerHp)
        {
            playerHp.health.takeDamage(10);
            hp.takeDamage(-10);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerHp = collision.GetComponent<PlayerController>();
        if (playerHp)
        {
            playerHp.health.takeDamage(1);
            hp.takeDamage(-1);
        }
    }
}
