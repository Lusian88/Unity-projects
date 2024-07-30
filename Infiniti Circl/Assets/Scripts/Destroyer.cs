using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) // срабытывает на триггер
    {
        if (other.gameObject.tag == "Enemy")// если препятствие соприкасаеться  со стеной то препятствие удаляется 
        {
            Destroy(other.gameObject);// удаление препятствия 
        }
    }


}
