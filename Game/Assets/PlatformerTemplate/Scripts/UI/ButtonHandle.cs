using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.IO;

public class ButtonHandle : MonoBehaviour
{
    //Read from a file
    //string something = File.ReadAllText("C:\\Rfile.txt");

    public void ChangeScene(string sceneName)
    {
        //Ace-SampleScene#1
        int p1 = sceneName.IndexOf('-');
        string character = sceneName.Substring(0, p1);
        string scene = sceneName.Substring(p1+1);
        if (character != "Default")//NOT This function has been called only to change the scene
        {
            //Saving data
            StreamWriter writer = new StreamWriter("SceneArgs.txt");
            writer.Write(character);
            writer.Close();
            //
            StreamReader sr = new StreamReader("SceneArgs.txt");
            string line = sr.ReadLine();
            Debug.Log(line);
        }
        //
        //Changing Scene
        Application.LoadLevel(scene);
    }
}