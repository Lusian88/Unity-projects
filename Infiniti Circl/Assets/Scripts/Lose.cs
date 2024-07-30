using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    public int score;
    public Text scoreText;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
    }
    private void Update()
    {
        scoreText.text = "Ваш рекорд " + score.ToString();
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);

    }

}
