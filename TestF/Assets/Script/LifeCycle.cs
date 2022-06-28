using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour {



    public LifeCycle(){
        Debug.Log("LifeCycle");
}

    public void Awake() {
        Debug.Log("Awake--" + Time.time + "--"+this.name);
    }


	// Use this for initialization
	void Start () {
        Debug.Log("Start--" + Time.time + "--" + this.name);
        int a = 1;
        int b = 2;
        int c = 1 + 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
