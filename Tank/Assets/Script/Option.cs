using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour {

    private int choice = 1;
    public Transform posO;
    public Transform posT;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) {
            choice = 1;
            transform.position = posO.position;
   
            PlayerPrefs.SetInt("PlayerNum",1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            choice = 2;
            transform.position = posT.position;
           
            PlayerPrefs.SetInt("PlayerNum",2);
        }
        if (choice == 1 && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("PlayerNum", 1);
        }
        if (choice == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("PlayerNum", 2);
        }
    }
}
