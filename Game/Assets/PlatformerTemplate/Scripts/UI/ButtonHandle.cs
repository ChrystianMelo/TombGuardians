using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonHandle : MonoBehaviour{
	static string character = "pattern";
	public void ChangeScene(string sceneName){
		character = sceneName;
		Debug.Log(character);
		Application.LoadLevel("SampleScene");//sceneName.Substring(0,(sceneName.Length-1)));
		//scene = sceneName.Substring(0,(sceneName.Length-1));
		//string args  = sceneName;//.Substring(sceneName.Length-1,sceneName.Length);
		//SceneManager.LoadScene("SampleScene", args);
	}
}