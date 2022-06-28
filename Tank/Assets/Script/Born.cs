using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {

    public GameObject[] tankFab;

    public GameObject[] emenyFabList;

    public bool createPlayerOne;
    public bool createPlayerTwo;
    // Use this for initialization
    void Start () {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject,0.8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BornTank() {
        if (createPlayerOne)
        {
            Instantiate(tankFab[0], transform.position, Quaternion.identity);
        }
        else if (createPlayerTwo)
        {
            Instantiate(tankFab[1], transform.position, Quaternion.identity);
        }
        else {
            //int num = Random.Range(2, 3);
            int num = Random.Range(0, 3);
            Instantiate(emenyFabList[num], transform.position, Quaternion.identity);
        }
    }
}
