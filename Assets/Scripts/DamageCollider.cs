using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {

    public int dmg = 34;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("AtaqueExitoso!");
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
