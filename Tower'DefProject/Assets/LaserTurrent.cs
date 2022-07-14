using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurrent : Turrent {

    public float damageRate = 70;
    public LineRenderer laserRenderer;
    public GameObject laserEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemies.Count > 0 && enemies[0] != null)
        {
            Vector3 targetPosition = enemies[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);

        }
        if (enemies.Count > 0)
        {   
            if (enemies[0] == null)
            {
                UpdateEnemies();
            }
            if (enemies.Count > 0)
            {
                if (laserRenderer.enabled == false) {
                    laserRenderer.enabled = true;
                    laserEffect.SetActive(true);

                }
                laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemies[0].transform.position });
                enemies[0].GetComponent<Enemy>().TakeDamage(damageRate*Time.deltaTime);
                laserEffect.transform.position = enemies[0].transform.position;
                Vector3 pos = transform.position;
                pos.y = enemies[0].transform.position.y;
                laserEffect.transform.LookAt(pos); 
            }
        }
        else {
            laserRenderer.enabled = false;
            laserEffect.SetActive( false);
        }
    }

     
}
