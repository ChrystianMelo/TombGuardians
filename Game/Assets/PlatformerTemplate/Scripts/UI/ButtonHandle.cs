﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandle : MonoBehaviour{
	public void ChangeScene(string sceneName){
		Application.LoadLevel(sceneName);
	}
}