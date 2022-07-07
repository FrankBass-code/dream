using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {

    [HideInInspector]
    public GameObject turretGo;

    public GameObject buildObj;

    public bool isUpgrade = false;

    private Renderer renderer ;

    private Turret turretData;

    public void BuildTurret(Turret turretFab) {
        this.turretData = turretFab;
        turretGo = GameObject.Instantiate(turretFab.turretFab, new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), Quaternion.identity);
        this.isUpgrade = false;
        GameObject effect = GameObject.Instantiate(buildObj, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void UpgradeTurret() {
        if (isUpgrade == true) { return; }
        Destroy(turretGo);
        turretGo = GameObject.Instantiate(turretData.turretUpgradedFab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        this.isUpgrade = true;
        GameObject effect = GameObject.Instantiate(buildObj, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);

    }

    public void DestoryTurret()
    {
        Destroy(turretGo);
        this.isUpgrade = false;
        turretData = null; ;
        turretGo = null;
        GameObject effect = GameObject.Instantiate(buildObj, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
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
