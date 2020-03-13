using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static int score = 0;
    public Text texto;
    public GameObject bat;
    public GameObject[] BatSpawn;
    public GameObject knight;
    public GameObject[] KnightSpawn;
    public GameObject shark;
    public GameObject bomb;
    float tempo = 1f;
    float redutor = 0;
    int maxInimigos = 20;
    public static int contador = 0;
    public static int remainingPlayers = 2;
    public static bool unleashed = false;
    public float maxSpawnTime = 3f;
    private float timeToSpawn;
    bool OnlyOne = false;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        remainingPlayers = 2;
        contador = 0;
        redutor = 0;
        unleashed = false;
        timeToSpawn = maxSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        int RandomEnemy = Random.Range(0, 4);
        texto.text = "Pontuação : " + score;
        
        tempo += Time.deltaTime;
        redutor += Time.deltaTime;
        if(tempo >= timeToSpawn && contador < maxInimigos && !unleashed)
        {
            switch(RandomEnemy)
            {
                case 0:
                    Instantiate(bat, BatSpawn[Random.Range(0, BatSpawn.Length)].transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(knight, KnightSpawn[Random.Range(0, KnightSpawn.Length)].transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(shark, KnightSpawn[Random.Range(0, KnightSpawn.Length)].transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bomb, KnightSpawn[Random.Range(0, KnightSpawn.Length)].transform.position, Quaternion.identity);
                    break;
            }
            contador++;
            tempo = 0;

        }

        if(redutor >= 30f)
        {
            
            timeToSpawn -= 0.25f;
            redutor = 0;
        }
        GameObject[] sobreviventes = GameObject.FindGameObjectsWithTag("Player");
        if(sobreviventes.Length == 0)
        {
            StreamWriter writer = new StreamWriter("GameOver.txt");
            writer.Write(score);
            writer.Close();
            Application.LoadLevel("GameOver");
        } else if(sobreviventes.Length == 1 && !OnlyOne)
        {
            timeToSpawn += 1f;
            OnlyOne = true;
        }

        GameObject[] TombDebugger = GameObject.FindGameObjectsWithTag("Tomb");
        if(TombDebugger.Length > 1)
        {
            int c = 0;
            while(c < TombDebugger.Length-1)
            {
                Destroy(TombDebugger[c]);
                c++;
            }
        }
    }
}
