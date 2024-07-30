using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;// переменная звука поежания клубники 

    private void OnTriggerEnter2D(Collider2D other )// функция работы с колайдерами 
    {
        RubyController controller = other.GetComponent<RubyController>();//обращение к скрипту руби контроллер 
        if (controller != null)// проверяет к тому ли элементу обращаються 
        {
            if (controller.health < controller.maxHealth)// если жизни меньше максимального значения 
            {
                controller.ChangeHealth(1);//триггер на блокировку спуска жизни ниже 0 или повышения больше максимального значения , плюсует к максимольному здоровью 1
               
                Destroy(gameObject);// удаляет ообъект жизнь 
                controller.PlaySound(collectedClip);// функция активации клипа 
            }
        }

    }


}
