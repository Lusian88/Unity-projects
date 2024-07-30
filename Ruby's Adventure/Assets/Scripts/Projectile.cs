using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    Rigidbody2D rigidbody2d;
    public float startTime;// переменная начала таймера для уничтожения снаряда 
    public float EndTime;//переменная конца таймера для уничтожения снаряда 
     
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    public void Launch(Vector2 direction, float force)//функция направления и силы движения снаряда 
    {
        rigidbody2d.AddForce(direction * force);//добавление силы риджедбоди 
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        //we also add a debug log to know what the projectile touch
        Debug.Log("Projectile Collision with " + other.gameObject);
        EnemyController e = other.collider.GetComponent<EnemyController>();//обращение к скрипту врага и создание переменной е 
        if (e != null)//условие при котором если снаряд касаеться колайдера врага то снаряд уничтожаеться 
        {
            e.Fix();
        }
         
        Destroy(gameObject);
        


    }
    void FixedUpdate()
    {
        startTime += 1f * Time.deltaTime;//прибавление к переменной конец таймер 
        if (startTime >= EndTime)// условие проверки если начало  больше или равно концу то снаряд изчезает 
        {
            Destroy(gameObject);
        }
    }
}
