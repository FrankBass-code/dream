using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Turret  {

    public GameObject turretFab;
    public int cost;
    public GameObject turretUpgradedFab;
    public int costUpgraded;
    public TurretType type;

    public enum TurretType {
        LaserTurret,
        MissileTurret,
        Turret
    }
}
