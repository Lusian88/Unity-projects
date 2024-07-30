using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("point"))
        {
            Destroy(other.gameObject);
        }
    }
}
