using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemySensor : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            this.GetComponentInParent<FlyingEnemy>().Attack();
        }
    }
}
