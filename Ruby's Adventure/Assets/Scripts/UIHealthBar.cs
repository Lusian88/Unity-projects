using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//библиотека использования юай элементов 

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }// не позволяет изменять эту фунцию в других скриптах , и сохраняет ее значение , но позволяет вызывать ее в других скриптах


    public Image mask;// переменная маски хп 
    float originalSize;//переменная полного хп 


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;// присваивание ширины маски максимкм 
    }

    // Update is called once per frame
    public void SetValue (float value)// общедоступная функция по сохранению текущего здоровья отображаемого в интерфейсе 
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
