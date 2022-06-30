using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static int countEnemyAlive = 0;
    public Wave[] waves;
    public float waveRate=0.3f;
    public Transform START;

    IEnumerator SpawnEnemy() {
           
        foreach (Wave wave in waves) {
            for (int i = 0; i < wave.count; i++) {
                GameObject.Instantiate(wave.enemyFab, START.position, Quaternion.identity);
                countEnemyAlive++;
                if (i != wave.count - 1)
                { yield return new WaitForSeconds(wave.rate); }
            }

            while (countEnemyAlive > 0) {
                yield return 0;
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
