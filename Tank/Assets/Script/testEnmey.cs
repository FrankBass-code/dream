using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnmey : Emeny {

    private void Die()
    {

        Instantiate(explosionFab, transform.position, transform.rotation);

        Destroy(gameObject);
        PlayerManager.Instance.score++;

        GameObject.Find("MapGenerator").GetComponent<MapGenerator>().CreateRandomBonus();


    }
}
