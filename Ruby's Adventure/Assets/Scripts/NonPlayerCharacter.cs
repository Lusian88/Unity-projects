using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;//переменная таймера сколько будет открыто в секундах диалоговое окно 
    public GameObject dialogBox;// обращение к канвасу Д О (ДО это диалоговое окно )
    float timerDisplay;// таймер отсчета жизни ДО

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);// выключаем ДО
        timerDisplay = -1.0f;// таймер изначально -1
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)//если таймер больше или равен 0 то запускаем таймер
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)// если таймер меньше 0 то закріваем ДО
            {
                dialogBox.SetActive(false);
            }
        }
    }
    public void DisplayDialog()// функция открытия ДО
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
