using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject[] item;
    public GameObject[] bonusItem;
    private List<Vector3> itemPositionLIst = new List<Vector3>();
    private float[] emenySpeeds;
    private GameObject[] emenys;

    private void Awake()
    {
        InitMap();
    }

    private void InitMap() {
        //heart
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        //wall
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -7, 0), Quaternion.identity);

        }
        //air wall
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);

        }

        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);

        }

        for (int i = -8; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);

        }
        for (int i = -8; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }
        //wall
        for (int i = 0; i < 60; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);

        }
        //
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }
        //player
        GameObject player = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        player.GetComponent<Born>().createPlayerOne = true;
        if (PlayerPrefs.GetInt("PlayerNum") == 2)
        {
            GameObject playerTwo = Instantiate(item[3], new Vector3(2, -8, 0), Quaternion.identity);
            playerTwo.GetComponent<Born>().createPlayerTwo = true;
        }
        //eneny
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEmeny", 4, 5);
    }

    private void CreateItem(GameObject itemObj,Vector3 position, Quaternion rotation) {
       GameObject item =  Instantiate(itemObj, position, rotation);
        item.transform.SetParent(gameObject.transform);
        itemPositionLIst.Add(position);
    }

    private Vector3 CreateRandomPosition() {
        while (true) {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!itemPositionLIst.Contains(createPosition)) {
                return createPosition; }
        }
    }

    public  void CreateRandomBonus()
    {

        int num = Random.Range(0, bonusItem.Length);
        //int num = 1;
        CreateItem(bonusItem[num], CreateRandomPosition(), Quaternion.identity);
    }

    private void CreateEmeny() {
        int num = Random.Range(0, 3);
        Vector3 emenyVector = new Vector3();
        if (num == 0) {
            emenyVector = new Vector3(-10, 8, 0);
        }
        if (num == 1)
        {
            emenyVector = new Vector3(0, 8, 0);
        }
        if (num == 2)
        {
            emenyVector = new Vector3(10, 8, 0);
        }

        CreateItem(item[3], emenyVector, Quaternion.identity);
    }



    public void StopEmeny()
    {
        emenys = GameObject.FindGameObjectsWithTag("Emeny");
        emenySpeeds = new float[emenys.Length];
        for (int i = 0; i < emenys.Length; i++)  //遍历数组，输出物件的名称
        {
            Debug.Log(emenys[i].name);
            emenySpeeds[i] = emenys[i].GetComponent<MoveSpeed>().moveSpeed;
            emenys[i].GetComponent<MoveSpeed>().moveSpeed = 0;

        }

        Invoke("RecoverEmeny", 3);
        //RecoverEmeny();
    }

    private void RecoverEmeny()
    {
        Debug.Log("RecoverEmeny....");
        for (int i = 0; i < emenys.Length; i++)  //遍历数组，输出物件的名称
        {
            Debug.Log(emenys[i].name);
            emenys[i].GetComponent<MoveSpeed>().moveSpeed = emenySpeeds[i];

        }

    }
}
