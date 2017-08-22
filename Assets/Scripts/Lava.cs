using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    [SerializeField]
    private float damage = 25;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Poison all over me!!");
            col.SendMessageUpwards("Damage", damage);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Poison all over me!!");
            col.SendMessageUpwards("Damage", damage);
        }
    }
}
