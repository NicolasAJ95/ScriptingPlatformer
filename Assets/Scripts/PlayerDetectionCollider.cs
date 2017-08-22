using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionCollider : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            this.GetComponentInParent<EnemySpawner>().playerIsNear = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            this.GetComponentInParent<EnemySpawner>().playerIsNear = false;
        }
    }
}
