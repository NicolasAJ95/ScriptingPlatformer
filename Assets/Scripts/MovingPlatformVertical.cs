using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour {

    public int movementAmount;
    public float speed;
    public bool movingUp = true;

    private Transform actualPosition;
    private Vector3 initialPosition;

    void Awake()
    {
        initialPosition = this.transform.position;
    }

    // Use this for initialization
    void Start()
    {
        actualPosition = this.transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (movingUp)
        {
            gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (actualPosition.position.y >= initialPosition.y + movementAmount)
            movingUp = false;

        if (actualPosition.position.y <= initialPosition.y - movementAmount)
            movingUp = true;


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            Debug.Log("MovingPlatformCollision");
            col.transform.parent = this.transform;
        }
    }


    void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.parent = this.transform.parent;
        }
    }
}
