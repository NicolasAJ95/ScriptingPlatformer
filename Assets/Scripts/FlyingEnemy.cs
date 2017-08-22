using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    private Rigidbody enemy_Rigidbody;

    [SerializeField]
    private bool movingRight;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float movementAmount;
    [SerializeField]
    private float health;

    public GameObject bulletPrefab;

    private Transform actualPosition;
    private Vector3 initialPosition;


    void Awake()
    {
        initialPosition = this.transform.position;
    }
    // Use this for initialization
    void Start()
    {
        enemy_Rigidbody = this.GetComponent<Rigidbody>();
        actualPosition = this.transform;
        //Patrol ();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        Patrol();
    }

    public void Damage(float damage)
    {
        health -= damage;
    }

    public void Attack()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bulletRigidBody = bullet.GetComponent<Rigidbody>();

        bullet.transform.position = this.transform.position;

        bulletRigidBody.AddForce(Vector3.down * bulletSpeed, ForceMode.Impulse);
    }

    public void Patrol()
    {
        Vector3 forces = Vector3.zero;      //Usamos un vector 3 para poder usar el transform.right. Para modificar la velocidad se debe crear un Vector2 o pasar por componentes.


        if (movingRight)
        {
          
            forces += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else
        {
        
            forces += Vector3.left * moveSpeed * Time.deltaTime;
        }

        enemy_Rigidbody.position += new Vector3(forces.x, 0, 0);

        if (actualPosition.position.x >= initialPosition.x + movementAmount)
            movingRight = false;

        if (actualPosition.position.x <= initialPosition.x - movementAmount)
            movingRight = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
