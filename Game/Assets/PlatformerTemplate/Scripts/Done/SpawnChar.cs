using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.IO;
using Platformer.Mechanics;
using UnityEngine.UI;

public class SpawnChar : MonoBehaviour
{

	public GameObject[] chars = new GameObject[5]; 
	[SerializeField] private GameObject spawnP1;
    [SerializeField] private GameObject spawnP2;
    public Slider[] vida = new Slider[2];
    PlayerController jogador1, jogador2;
    public Text P2text;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1Pos = spawnP1.transform.position;
        Vector3 p2Pos = spawnP2.transform.position;
        StreamReader sr = new StreamReader("SceneArgs.txt");
        string line = sr.ReadLine();
        

        switch(line) {

        	case "Ace" : 
        		jogador1 = Instantiate(chars[0], p1Pos, Quaternion.identity).GetComponent<PlayerController>();
            	jogador1.playerID = 1;
    			break;
            case "Anny":
                jogador1 = Instantiate(chars[1], p1Pos, Quaternion.identity).GetComponent<PlayerController>();
                jogador1.playerID = 1;
                break;
            case "Balthar" : 
        		jogador1 = Instantiate(chars[2], p1Pos, Quaternion.identity).GetComponent<PlayerController>();
            	jogador1.playerID = 1;
    			break;
            case "Dion":
                jogador1 = Instantiate(chars[3], p1Pos, Quaternion.identity).GetComponent<PlayerController>();
                jogador1.playerID = 1;
                break;
            case "Viper" : 
        		jogador1 = Instantiate(chars[4], p1Pos, Quaternion.identity).GetComponent<PlayerController>();
            	jogador1.playerID = 1;
    			break;
        }

        jogador1.health.healthSlider = vida[0];

        string line2 = sr.ReadLine();

        switch (line2)
        {

            case "Ace":
                jogador2 = Instantiate(chars[0], p2Pos, Quaternion.identity).GetComponent<PlayerController>();
                jogador2.playerID = 2;
                break;
            case "Anny":
                jogador2 = Instantiate(chars[1], p2Pos, Quaternion.identity).GetComponent<PlayerController>();
                jogador2.playerID = 2;
                break;
            case "Balthar":
                jogador2 = Instantiate(chars[2], p2Pos, Quaternion.identity).GetComponent<PlayerController>();
                jogador2.playerID = 2;
                break;
            case "Dion":
                jogador2 = Instantiate(chars[3], p2Pos, Quaternion.identity).GetComponent<PlayerController>();
                jogador2.playerID = 2;
                break;
            case "Viper":
                jogador2 = Instantiate(chars[4], p2Pos, Quaternion.identity).GetComponent<PlayerController>();
                jogador2.playerID = 2;
                break;
            case "None":
                Destroy(vida[1].gameObject);
                Destroy(P2text);
                break;
        }
        jogador2.health.healthSlider = vida[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
