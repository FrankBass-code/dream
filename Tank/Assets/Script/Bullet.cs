using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed = 10;

    public bool isPlayerB;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag) {
            case "Tank":
                if (!isPlayerB) { 
                 collision.SendMessage("Die");

                    Destroy(gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Emeny":
                if (isPlayerB)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(audioClips[1], transform.position);
                break;
            case "Barriar":
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(audioClips[0], transform.position);
                break;
            default:
                break;
        }
    }
}
