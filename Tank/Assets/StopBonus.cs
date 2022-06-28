using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopBonus : MonoBehaviour
{
    private float[] emenySpeeds;
    private GameObject[] emenys;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                //StopEmeny();
                //Invoke("ReturnToMain", 2);
                GameObject.Find("MapGenerator").GetComponent<MapGenerator>().StopEmeny();
                Destroy(gameObject);
               
                break;
            default:
                break;
        }
    }

    public void StopEmeny() {
         emenys = GameObject.FindGameObjectsWithTag("Emeny");
        emenySpeeds = new float[emenys.Length];
        for (int i = 0; i < emenys.Length; i++)  //遍历数组，输出物件的名称
        {
            Debug.Log(emenys[i].name);
            emenySpeeds[i] = emenys[i].GetComponent<MoveSpeed>().moveSpeed;
            emenys[i].GetComponent<MoveSpeed>().moveSpeed = 0;
         
        }
      
        StartCoroutine(Delayed());
        RecoverEmeny();
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
    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(6);//6秒之后执行之后的语句
      RecoverEmeny();
    }

    private void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
