using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private float life = 100;
    [SerializeField]
    private float spawnTime = 1.5f;
    [SerializeField]
    private float spawnRate = 0.5f;
    
    public bool playerIsNear;
    public GameObject enemyPrefab;

    // Use this for initialization
    void Start () {
        playerIsNear = false;
        InvokeRepeating("SpawnEnemy", spawnTime, spawnRate * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
        if (life <= 0)
            Die();
	}

    private void SpawnEnemy()
    {
        if (playerIsNear == true)
        {
            GameObject enemy = Instantiate ( enemyPrefab, transform .position, transform.rotation) as GameObject ;
            Rigidbody  enemyRigidBody = enemy.GetComponent<Rigidbody>();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        life -= damage;
    }

}
