using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float dmg = 34;
    public float hsDmg = 200;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag ( "Enemy"))
        {
            Debug.Log("Enemy hit");
            col.gameObject.SendMessageUpwards("Damage", dmg);
            Destroy(gameObject);
        }

        
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("EnemyHead"))
        {
            Debug.Log("Headshot");
            col.gameObject.SendMessageUpwards("Damage", hsDmg);
        }

    }
}
