using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformHorizontal : MonoBehaviour {
    public int movementAmount;
    public float speed;
    public bool movingRight = true;

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

        if (movingRight)
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (actualPosition.position.x >= initialPosition.x + movementAmount)
            movingRight = false;

        if (actualPosition.position.x <= initialPosition.x - movementAmount)
            movingRight = true;


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
