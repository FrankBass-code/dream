using UnityEngine;
using System.Collections;

public class PlayerTwo : MonoBehaviour {

    public float moveSpeed = 3;
    private Vector3 bulletEulAngles;
    private float fireCd;
    private float isDefTimer = 3;
    private SpriteRenderer sr;
    public float v;
    public float h;

    private bool isDef = true;

    public Sprite[] tankSr;
    public GameObject bullectFab;
    public GameObject explosionFab;
    public GameObject defFab;
    public AudioSource moveAudio;
    public AudioClip[] tankAudio;
    void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isDef) {
            defFab.SetActive(true);
            isDefTimer -= Time.deltaTime;
            if (isDefTimer <= 0) {
                isDef = false;
                defFab.SetActive(false);
            }
        }

        if (v  == 0&&h==0)
        {
            moveAudio.clip = tankAudio[0];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            
            moveAudio.clip = tankAudio[1];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }


    }


    private void FixedUpdate()
    {

        if (PlayerManager.Instance.isDefeat) { return; }
        Move();
        if (fireCd >= 0.4f)
        {
            Attack();
        }
        else
        {
            fireCd += Time.deltaTime;
        }

    }


    private void Attack() {
        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            Instantiate(bullectFab, transform.position,Quaternion.Euler(transform.eulerAngles+ bulletEulAngles));
            fireCd = 0;
        }

    }


    private void Move()
    {
         v = Input.GetAxisRaw("VerticalTwo");
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
        //if (Mathf.Abs(v) > 0.05f) {
        //    moveAudio.clip = tankAudio[1];

        //    if (!moveAudio.isPlaying)
        //    {
        //        moveAudio.Play();
        //    }
        //}

        if (v != 0) { return; }
         h = Input.GetAxisRaw("HorizontalTwo");
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
        //if (Mathf.Abs(h) > 0.05f)
        //{
        //    moveAudio.clip = tankAudio[1];

        //    if (!moveAudio.isPlaying)
        //    {
        //        moveAudio.Play();
        //    }
        //}
        //else {
        //    moveAudio.clip = tankAudio[0];
        //    if (!moveAudio.isPlaying)
        //    {
        //        moveAudio.Play();
        //    }
        //}
    }




    private void Die() {
        if (!isDef)
        {
            PlayerManager.Instance.isDeadTwo = true;
            Instantiate(explosionFab, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    private void getHP()
    {

        PlayerManager.Instance.HPTwo++;


    }

}
