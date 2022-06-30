using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Transform[] positions;
    public float speed = 10;
    private int index = 0;
	// Use this for initialization
	void Start () {
        positions = WayPoint.positions;

    }
	
	// Update is called once per frame
	void Update () {
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
}
