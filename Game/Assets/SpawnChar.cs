using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.IO;

public class SpawnChar : MonoBehaviour
{

	public GameObject[] chars = new GameObject[5]; 
	public GameObject spawnP1;
	private Transform p1Pos = spawnP1.transform.position;
    // Start is called before the first frame update
    void Start()
    {
        StreamReader sr = new StreamReader("SceneArgs.txt");
        string line = sr.ReadLine();

        switch(line) {

        	case "Ace" : Instantiate(chars[0], p1Pos);
        				break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
