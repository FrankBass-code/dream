using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public Turret laserTurretData;
    public Turret missileTurretData;
    public Turret turretData;

    public Turret selectedTurretData;
    public Text moneyText;
    public Animator moneyAnimator;

    public int money = 1000;

    // Use this for initialization
    void Start () {
		
	}

    void ChangeMoney(int change = 0) {
        money += change;
        moneyText.text = "$" + money;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if (EventSystem.current.IsPointerOverGameObject()==false) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCol =  Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCol) {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        if (money >= selectedTurretData.cost)
                        {
                            money -= selectedTurretData.cost;
                            mapCube.BuildTurret(selectedTurretData.turretFab);
                            ChangeMoney(-selectedTurretData.cost);
                        }
                        else {
                            moneyAnimator.SetTrigger("Flick");
                        }
                    }
                    else if(mapCube.turretGo != null)
                    {

                    }   
                }
            }
        }
	}


    public void OnLaserSelected(bool isOn) {
        if (isOn) {
            selectedTurretData = laserTurretData;


        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;


        }
    }

    public void OnTurretSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = turretData;


        }
    }
}
