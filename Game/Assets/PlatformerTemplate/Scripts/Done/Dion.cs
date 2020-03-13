using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dion : MonoBehaviour
{
    public GameObject ShootPoint;
    private int player;
    public GameObject ball;
    public float reloadTime = 0.5f;
    private float lastShot = 0;
    public static float resetTimer = 0;
    public Text streakText;
    public static int streak = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>().playerID;
        streak = 0;
        streakText.text = streak + " ";
    }

    // Update is called once per frame
    void Update()
    {
        streakText.text = streak + " ";
        if ((player == 1 && Input.GetButton("Fire1")) || (player == 2 && Input.GetButton("Fire(S)")))
        {
            Shoot();
        }
        resetTimer += Time.deltaTime;
        if(resetTimer >= 2f)
        {
            streak = 0;
        }
    }

    void Shoot()
    {
        float tempo = Time.time;
        if (tempo >= lastShot + reloadTime)
        {
            lastShot = tempo;
            SolarBall tiro = Instantiate(ball, ShootPoint.transform.position, ShootPoint.transform.rotation).GetComponent<SolarBall>();
            tiro.damage = 30 + 2 * streak;
        }
    }
}