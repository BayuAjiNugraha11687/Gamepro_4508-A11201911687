using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateObs : MonoBehaviour
{
    public GameObject rocks;
    int score = 0;
    public Text ScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObstacle", 1f, 1.5f);
    }

    void CreateObstacle()
    {
        Instantiate (rocks);
        score++;
        SaveLoadHighscore.SaveHighScore(score);
        if (score >= 5)
            GUIManager.saveLevel(1);
        if (score >= 10)
            GUIManager.saveLevel(2);
    }
    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = "Score : " + score.ToString();
        SaveLoadHighscore.SaveHighScore (score);
    }
}
