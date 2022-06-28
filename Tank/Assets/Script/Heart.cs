using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    private SpriteRenderer sr;
    public Sprite broken;
    public GameObject explosionFab;
    public AudioClip dieAutdio;

  // Use this for initialization
  void Start () {
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die() {

        sr.sprite = broken;
        Instantiate(explosionFab, transform.position, transform.rotation);
        PlayerManager.Instance.isDefeat = true;
        AudioSource.PlayClipAtPoint(dieAutdio, transform.position);
    }
}
