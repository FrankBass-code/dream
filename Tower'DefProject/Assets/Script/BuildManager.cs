using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public Turret laserTurretData;
    public Turret missileTurretData;
    public Turret turretData;

    public Turret selectedTurretData;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
