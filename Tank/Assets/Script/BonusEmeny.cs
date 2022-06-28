using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BonusEmeny : MonoBehaviour {

    public float moveSpeed = 3;
    private Vector3 bulletEulAngles;
    private float fireCd;

    private SpriteRenderer sr;
    private float timeValChangeHead;
    private float h =0;
    private float v = -1;

    public Sprite[] tankSr;
    public GameObject bullectFab;
    public GameObject explosionFab;
    public GameObject mapGenerator;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var addr = getMemory(this);
        Debug.Log(addr);

        if (fireCd >=3)
        {
            Attack();
        }
        else
        {
            fireCd += Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        moveSpeed = gameObject.GetComponent<MoveSpeed>().moveSpeed;
        Move();

    }


    private void Attack()
    {
      
            Instantiate(bullectFab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulAngles));
            fireCd = 0;
       

    }


    private void Move()
    {
     
        if (timeValChangeHead >= 4) {
            int num = UnityEngine.Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num < 2)
            {
                v = 0;
                h = -1;
            }
            else if (num > 2 && num < 4)
            {
                v = 0;
                h = 1;
            }
            timeValChangeHead = 0;
        }
        else
        {
            timeValChangeHead += Time.fixedDeltaTime;
        }

      //  v = Input.GetAxisRaw("Vertical"); 
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSr[2];
            bulletEulAngles = new Vector3(0, 0, -180);

        }
        else if (v > 0)
        {
            sr.sprite = tankSr[0];
            bulletEulAngles = new Vector3(0, 0, 0);
        }

        if (v != 0) { return; }
         //h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSr[3];
            bulletEulAngles = new Vector3(0, 0, 90);

        }
        else if (h > 0)
        {
            sr.sprite = tankSr[1];
            bulletEulAngles = new Vector3(0, 0, -90);
        }
    }

    public string getMemory(object o) // 获取引用类型的内存地址方法    
    {
        GCHandle h = GCHandle.Alloc(o, GCHandleType.WeakTrackResurrection);

        IntPtr addr = GCHandle.ToIntPtr(h);

        return "0x" + addr.ToString("X");
    }




    private void Die()
    {
     
            Instantiate(explosionFab, transform.position, transform.rotation);

            Destroy(gameObject);
             PlayerManager.Instance.score ++;

        GameObject.Find("MapGenerator").GetComponent<MapGenerator>().CreateRandomBonus();


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Emeny") {
        
            v = -v;
            h = -h;
            timeValChangeHead = 4;
        }
    }


}
