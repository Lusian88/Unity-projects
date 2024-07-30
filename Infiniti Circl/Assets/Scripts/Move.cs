using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    [SerializeField] GameObject CenterCircle;
    bool direction = false;
    void FixedUpdate()
    {
        if (direction == false) //изменение направления в реальном времени 
        CenterCircle.transform.Rotate(0, 0, 150 * Time.deltaTime); // смена параметров ротате 
        else
            CenterCircle.transform.Rotate(0, 0, -150 * Time.deltaTime);
    }
    public void ChangeDirection()
    {
        direction = !direction; // есои кнопка нажата то смнена направления 
    }
}
