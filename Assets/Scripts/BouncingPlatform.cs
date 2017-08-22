using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatform : MonoBehaviour {

    public float speed = 10.0f;
    
    private Vector3 velocity = Vector3.zero;

    void OnCollisionEnter(Collision col)
    {
        var player = col.gameObject.GetComponent<Rigidbody>();
        player.AddForce(transform.up * speed);
    }
}
