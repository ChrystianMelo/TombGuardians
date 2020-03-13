using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        StreamReader sr = new StreamReader("GameOver.txt");
        string line = sr.ReadLine();

        scoreText.text = "Pontuação final : " + line;
    }
}
