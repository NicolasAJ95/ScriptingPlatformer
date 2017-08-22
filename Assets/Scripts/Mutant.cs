using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour {

    [SerializeField]
    private float health = 100;
    [SerializeField]
    private Vector3 range = new Vector3 (5,5,5);
    private Rigidbody rb;
    public float speed = 300f;

    private GameObject  target;

    public bool attacking;
    private bool facingRight;

    private float attackTimer = 0.0f;

    public float attackCooldown = 0.4f;
    public Collider meleeTrigger;
    public float implodeTime = 0.7f;

    // Use this for initialization
    void Start () {
        meleeTrigger.enabled = false;
        attacking = false;

        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
       if (health <= 0)
            Die();

        Vector3 dir = transform.position - target.GetComponent<Transform>().position;
        transform.position += new Vector3(-dir.normalized .x, 0, 0) * speed * Time.fixedDeltaTime;
        if (dir.x < range.x)
            Implode();

        //Flip conditions
        if (dir.x < 0)
            facingRight = true;
        else
            facingRight = false;

        Flip();
    }

    void Flip()
    {
        Vector3 localTransform = transform.localScale;

        if (facingRight == true)
        {
            localTransform.z = -2f;
        }
        else
        {
            localTransform.z = 2f;
        }

        transform.localScale = localTransform;

    }

    void Implode()
    {
        Debug.Log("allah uh akbar");
        meleeTrigger.enabled = true;
        //yield return new WaitForSeconds (implodeTime);
        InvokeRepeating("Die", implodeTime, 1);
    }

    public void Damage(float damage)
    {

        health -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        
    }
}
