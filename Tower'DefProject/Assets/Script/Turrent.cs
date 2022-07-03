using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour {

    public List<GameObject> enemies = new List<GameObject>();

    public float attackRateTime = 1;
    float  timer = 0;

    public GameObject bulletFab;
    public Transform firePosition;
    public Transform head;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            enemies.Add(other.gameObject);
        }
        
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        timer = attackRateTime;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (enemies.Count > 0 && enemies[0] != null)
        {
            Vector3 targetPosition = enemies[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);

        }

     
        if (enemies.Count>0&&timer > attackRateTime) {
            timer =0;
            Attack();

        }
      


    }

    void Attack() {
        if (enemies[0] == null)
        {
            UpdateEnemies();
            
        }
        if (enemies.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletFab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemies[0].transform);
        }
        else {
            timer = attackRateTime;
        }
    }

    void UpdateEnemies() {

        RemoveNull();
    }

  void  RemoveNull()
    {
        // 找出第一个空元素 O(n)
        int count = enemies.Count;
        for (int i = 0; i < count; i++)
            if (enemies[i] == null)
            {
                // 记录当前位置
                int newCount = i++;

                // 对每个非空元素，复制至当前位置 O(n)
                for (; i < count; i++)
                    if (enemies[i] != null)
                        enemies[newCount++] = enemies[i];

                // 移除多余的元素 O(n)
                enemies.RemoveRange(newCount, count - newCount);
                break;
            }

    }
}
