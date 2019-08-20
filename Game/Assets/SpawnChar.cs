using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.IO;
using Platformer.Mechanics;

public class SpawnChar : MonoBehaviour
{

	public GameObject[] chars = new GameObject[5]; 
	[SerializeField] private GameObject spawnP1;
	 
    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1Pos = spawnP1.transform.position;
        StreamReader sr = new StreamReader("SceneArgs.txt");
        string line = sr.ReadLine();
        PlayerController jogador1;

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
