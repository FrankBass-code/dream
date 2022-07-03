using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Transform[] positions;
    public float speed = 10;
    private int index = 0;
    public int HP = 150;
    public GameObject explosionFab;

    // Use this for initialization
    void Start() {
        positions = WayPoint.positions;

    }

    // Update is called once per frame
    void Update() {
        Move();

    }

    private void Move()
    {
        if (index < positions.Length)
        {
            transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
            if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
            {
                index++;
            }
        }
        else {
            ReachDestination();
        }
    }

    void ReachDestination()
    {

        GameObject.Destroy(this.gameObject);
        EnemySpawner.countEnemyAlive--;

    }

    void OnDestory()
    {
        EnemySpawner.countEnemyAlive--;

    }

    public void TakeDamage(int damage) {
        if (HP <= 0) {
            return;
        }
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect =  GameObject.Instantiate(explosionFab, transform.position, transform.rotation);
        Destroy(effect,1.5f);
        Destroy(gameObject);
        EnemySpawner.countEnemyAlive--;


    }
}
