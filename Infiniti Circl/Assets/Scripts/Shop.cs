using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public int money;
    public Text moneyText;
    public bool isMulti = false;
    // Start is called before the first frame update
    void Start()
    {
        money = PlayerPrefs.GetInt("Money");
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Доступно очков " + money.ToString();
    }
    public void BuyMulti()
    {
        if (money >= 10 && isMulti == false )
        {
            isMulti = true;
            money -= 10;
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetInt("isMulti", isMulti ? 1 : 0);//сохранение в реестре логических элементов
        }
    }
    public void ExitShop()
    {
        SceneManager.LoadScene(0);
    }
}
