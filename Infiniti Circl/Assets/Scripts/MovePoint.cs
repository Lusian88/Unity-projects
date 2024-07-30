using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField] GameObject point;
    [SerializeField] float speed;
    void FixedUpdate()
    {
        point.transform.Translate(speed * Time.deltaTime  , 0 , 0 );

        
    }

}
