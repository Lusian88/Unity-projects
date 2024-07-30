using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)//функция работы с колайдерами 
    {
        RubyController controller = other.GetComponent<RubyController>();//обращение к управляющему скрипту руби 
        if(controller != null)// проверка не являеться ли скрипт пустой
        {
            controller.ChangeHealth(-1);//отнимает жизни у руби при столкновении 
        }
    }
}
