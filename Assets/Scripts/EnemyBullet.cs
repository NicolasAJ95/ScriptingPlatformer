using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float dmg = 20;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag( "Player"))
        {
            Debug.Log("wtf enemy bullet");
            col.gameObject.SendMessageUpwards("Damage", dmg);
            Destroy(gameObject);

        }
        
    }
}
