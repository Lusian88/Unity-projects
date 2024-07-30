using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1;//переменная скорости 
    public bool vertical;// переменая смены направления 
    public float changeTime = 3.0f;// переменная таймера смены направления
    public ParticleSystem smokeEffect;// слот для визуальных эффектов 


    Rigidbody2D rigidbody2D;
    Animator animator;
    float timer;// переменная таймера 
    int direction = 1;// переменная смены направления 

    bool broken = true; // переменная проверки состояния робота 
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;// приравнивания таймера к времени 
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!broken)//условие проверки состояния робота 
        {
            return;
        }

        timer -= Time.deltaTime;// обновление в реальномвремени 
        if (timer < 0)// если таймер закончился 
        {
            direction = -direction;// смена направления 
            timer = changeTime;//обновление времени таймера 
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (!broken)//условие проверки состояния робота 
        {
            return;
        }

        if (vertical)// условие смены направления используя систему координат , если нажать на галку тригер вертикали , то будет выполнено условие иначе либо вертикаль , либо горизонталь 
        {
            position.y = position.y + Time.deltaTime * speed * direction;//перемещение в реальном времени по вертикали 
            //сохранение анимании по вертикали 
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;// перемещение в реальном времени по горизонтали 
            //сохранение анимании по горизонтали 
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2D.MovePosition(position);


    }
     void OnCollisionEnter2D(Collision2D other)//функция домага врага через вход колайдера (не нахождение)
        
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()// функция выполняеться если снаряд коснулся робота , и чиниет меняет переменную сломан на ложь 
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();// останавливает анимацию дыма после починки 
        
    }
}
