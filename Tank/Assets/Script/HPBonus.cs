using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBonus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                
                    collision.SendMessage("getHP");

                    Destroy(gameObject);
                
                break;
            default:
                break;
        }
    }
}
