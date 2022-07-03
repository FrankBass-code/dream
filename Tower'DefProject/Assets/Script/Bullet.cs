using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public int damage = 50;
    public float speed = 20f;

    private Transform target;

    public GameObject explosion;
    public void SetTarget(Transform _target) {
        this.target = _target;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null) {
            Die();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Die();
        }
    }

    void Die() {
        GameObject effect = GameObject.Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 1);
    }
}
