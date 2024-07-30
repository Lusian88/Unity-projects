using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScripts : MonoBehaviour
{
    public int score;
    public int x = 1;
    public bool isMulti;
    public GameObject bonusEffect;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject point;
    public void Start()
    {
        isMulti = PlayerPrefs.GetInt("isMulti") == 1 ? true : false ;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag == "point")
         {
            Destroy(other.gameObject);
            Instantiate(bonusEffect, transform.position, Quaternion.identity);
            if (isMulti)
            {
                score += 2;

            }
            else
            {
                score++;
            }
         }
         if (other.gameObject.tag == "Enemy")
         {
            Destroy(other.gameObject);
            isMulti = false;
            PlayerPrefs.SetInt("score", score);//Сохранения данных в реестр для передачи их в другие сцены
            PlayerPrefs.SetInt("isMulti", isMulti ? 1 : 0);
            SceneManager.LoadScene(2);
             
         }
    }
    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
