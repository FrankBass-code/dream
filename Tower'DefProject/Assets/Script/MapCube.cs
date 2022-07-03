using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {

    [HideInInspector]
    public GameObject turretGo;

    public GameObject buildObj;

    private Renderer renderer ;

    public void BuildTurret(GameObject turretFab) {
        turretGo = GameObject.Instantiate(turretFab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildObj, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }
    
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnMouseEnter()
    {
        if (turretGo == null && EventSystem.current.IsPointerOverGameObject() == false) {

            renderer.material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
