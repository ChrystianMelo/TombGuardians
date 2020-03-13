using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.IO;

public class ButtonHandle2 : MonoBehaviour
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
            StreamReader sr = new StreamReader("SceneArgs.txt");
            string line = sr.ReadLine();
            sr.Close();
            StreamWriter writer = new StreamWriter("SceneArgs.txt");
            writer.WriteLine(line);
            writer.Write(character);
            writer.Close();
            //
        }
        //
        //Changing Scene
        Application.LoadLevel(scene);
    }
}