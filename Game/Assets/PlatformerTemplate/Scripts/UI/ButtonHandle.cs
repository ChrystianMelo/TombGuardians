using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.IO;

public class ButtonHandle : MonoBehaviour{
	//Read from a file
	//string something = File.ReadAllText("C:\\Rfile.txt");

	public void ChangeScene(string sceneName){
		//Saving data
		StreamWriter writer = new StreamWriter("SceneArgs.txt");
    	writer.Write(sceneName);
    	writer.Close();
    	//
    	StreamReader sr = new StreamReader("SceneArgs.txt");
        string line = sr.ReadLine();
        Debug.Log(line);
    	//
    	//Changing Scene
		Application.LoadLevel("SampleScene");
	}
}