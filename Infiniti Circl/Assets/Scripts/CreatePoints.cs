using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoints : MonoBehaviour
{
    public Transform Spawnpos;
    [SerializeField] Vector2 range;
    [SerializeField] GameObject point;
    void Start()
    {
        StartCoroutine(Spawned());
    }
    IEnumerator Spawned()
    {
        yield return new WaitForSeconds(3);
        Vector2 pos = Spawnpos.position + new Vector3(0, Random.Range(-range.y, range.y));
        Instantiate(point, pos, Quaternion.identity);
        Repeat();
    }


    void Repeat()
    {
        StartCoroutine(Spawned());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}