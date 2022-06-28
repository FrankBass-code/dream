using UnityEngine;
using System.Collections;

public class FindEmeny : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void OnGUI() {
        if (GUILayout.Button("findMinHPEm")) {
            Emeny[] ems = Object.FindObjectsOfType<Emeny>();
            Emeny em = FindEmenyByMinHp(ems);
            em.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public Emeny FindEmenyByMinHp(Emeny[] ems) {
        Emeny ret = ems[0];
        for (int i = 0; i < ems.Length; i++) {
            if (ems[i].HP < ret.HP) {
                ret = ems[i];
            }
            }

            return ret;
    
    }
}
