using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Wave[] waves;
    public float waveRate=3;
    public Transform START;

    IEnumerator SpawnEnemy() {

        foreach (Wave wave in waves) {
            for (int i = 0; i < wave.count; i++) {
                GameObject.Instantiate(wave.enemyFab, START.position, Quaternion.identity);
                if (i != wave.count - 1)
                { yield return new WaitForSeconds(wave.rate); }
            }
            yield return new WaitForSeconds(waveRate);
        }
    }



	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
