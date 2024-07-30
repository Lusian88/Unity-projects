using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour
{
    public float speed;

    public GameObject projectilePrefab; // переменная снаряда 
    public ParticleSystem hillAnim;

    public int maxHealth = 5;//максимальное значение здоровья 
    public float timeInvincible = 2.0f;//переменная времени неуязвимости 

    public int health { get { return currentHealth; } }
    int currentHealth;// текущее значение здоровья 


    bool isInvincible ;// переменная булего значения 
    float invincibleTimer;// таймер неуязвимости 


    Rigidbody2D rigidbody2d; // обращение к риджитбоди обьявление переменной риджетбоди
    Animator animator;// вызов аниматора 
    float horizontal; // переменная движения горизонталь 
    float vertical;//  переменная движения вертикаль

    Vector2 lookDirection = new Vector2(1, 0);// переменная на сохранение значиний для смены анимация горизонтальной или вертикальной 

    AudioSource  audioSource;
    public AudioClip audioClip; //переменная(слот) для звука броска 

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // инициализация риджедбоди в функции старт
        animator = GetComponent<Animator>();//инициализация аниматора 
        currentHealth = maxHealth; // приравниваем максимальное значение жизней на начало запуска сцены 

        audioSource = GetComponent<AudioSource>();//сохранение источника звука аудио сорс 
        
    }
    public void PlaySound(AudioClip clip)// которая принимает AudioClip в качестве параметра
    {
        audioSource.PlayOneShot(clip);//функция которая вызывает звук разово при опрнделенном триггере 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");// назначения кнопки на горизонтальное движение 
        vertical = Input.GetAxis("Vertical");// назначения кнопки на вертикальное движение 
        Vector2 move = new Vector2(horizontal, vertical);// переменная которая сохраняет хводное значение икс и игрик одновременно 

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))// проверка не равны ли значения нулю 
        {
            lookDirection.Set(move.x, move.y);// сохраняет текущее направление руби 
            lookDirection.Normalize();// нормализует значение переменной move приводя ее к значению 0 или 1 ровно 
        }
        // эти три переменные передют значение в аниматор в какую сторону сейчас смотрит руби 
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);



        if (isInvincible) //если триггер активый включаеться таймер
        {
            invincibleTimer -= Time.deltaTime;// таймер вкл 
          
            if (invincibleTimer < 0)//если таймер офф 
                isInvincible = false;// она смертная 
        }
        if (Input.GetKeyDown(KeyCode.C))// по нажатию вызываеться функция выстрела 
        {
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.X))// по нажатию х вызываеться диалоговое окно 
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));// переменная луча которая будет проверять направление персонажа с помощью lookDirection и считывать колайдеры которые она прохотит .
           
            if (hit.collider != null)// проверка не являеться ли объект пустой 
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();//вызиваем скрипт NPC
                if (character != null)
                {
                    character.DisplayDialog();//запускаем ДО
                }
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;//смена позиции персонажа по горизонтали в реальном времени 
        position.y = position.y + speed * vertical * Time.deltaTime;//смена позиции персонажа по вертикали в реальном времени 
        rigidbody2d.MovePosition(position); // двигает на прямую риджидбоди 
    }
    public void ChangeHealth(int amount)// функция смены жизней 
    {
       
        
            if (amount < 0)//если значение меньше нуля 
            {
               animator.SetTrigger("Hit");// сохраняет значение удара для аниматора 
               if (isInvincible)// если неуяз неактивный выходим из функции 
                    return;

                isInvincible = true;// а если активный
                invincibleTimer = timeInvincible;//обновляем таймер 
            }
            if (amount > 0)
            {
            //тут будут анимации получения урона и хилла 
            ParticleSystem hillAnimParticle = Instantiate(hillAnim, rigidbody2d.position + Vector2.up * 0.5f , Quaternion.identity);// функция вызова анимации хила 


            }
        
            
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);// динамическое сохранение текущего здоровья , а также принудительное преобразования целочисленной переменной maxHealth в переменную с плаваюзей точной 
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);// создает копию префаба снаряда 
        Projectile projectile = projectileObject.GetComponent<Projectile>();// получает доступ к скрипту снаряда 
        projectile.Launch(lookDirection, 300);// вызываем функцию лаунч , и проверяет направление персонажа , задает силу снаряда
        animator.SetTrigger("Launch");// активирует анимацию для снаряда 
        
        PlaySound(audioClip);//вызов звука броска 

    }



}
