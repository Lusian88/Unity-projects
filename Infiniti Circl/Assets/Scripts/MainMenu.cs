using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public int money;
    public int earnedMoney;
    public Text moneyText;
    public void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        earnedMoney = PlayerPrefs.GetInt("score");
        money += earnedMoney;
        PlayerPrefs.SetInt("Money", money);
        moneyText.text = " Доступные средства " + money.ToString();
        earnedMoney = 0;
        PlayerPrefs.SetInt("score", earnedMoney);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1); // метод SceneManager и компонент LoadScene
    }
    public void Shop()
    {
        SceneManager.LoadScene(3);
    }
}
