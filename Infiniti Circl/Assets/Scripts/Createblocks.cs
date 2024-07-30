using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createblocks : MonoBehaviour
{
    public Transform spawnPos; // место спавна препятствий
    [SerializeField] Vector2 range;// промежуток по которому допустимо создание припятствий 
    [SerializeField] GameObject enemy;// объект который будет создан
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn() //метод открывает возможность использовать карутины 
    {
        yield return new WaitForSeconds(2);//переодичность выполнения действия 
        Vector2 pos = spawnPos.position + new Vector3(0, Random.Range(-range.y, range.y));// новая точка создания объекта 
        Instantiate(enemy, pos, Quaternion.identity); // спавн объекта ( Quaternion выставить координаты на 0)
        Repeat();
    }
    void Repeat()
    {
        StartCoroutine(Spawn());
    }
}
