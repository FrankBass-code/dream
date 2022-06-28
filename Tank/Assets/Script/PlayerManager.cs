using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    public int HPOne = 3;
    public int HPTwo = 3;
    public int score = 0;
    public bool isDeadOne;
    public bool isDeadTwo;
    public int playerNum;
    public bool isDefeat;
    public GameObject born;
    public Text playScoreText;
    public Text playHPOneText;
    public Text playHPTwoText;
    public GameObject isDefeatUI;
    public GameObject isPlayerTwo;

    private static PlayerManager instance;

    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    void Awake()
    {
        Instance = this;
        isDefeatUI.SetActive(false);
        if (PlayerPrefs.GetInt("PlayerNum") != 2){
            isPlayerTwo.SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnToMain", 3);
            return;
        }
        if (isDeadOne) {
            RecoverOne(); 
        }
        if (isDeadTwo)
        {
            RecoveTwo();
        }
        playScoreText.text = score.ToString();
        playHPOneText.text = HPOne.ToString();
        playHPTwoText.text = HPTwo.ToString();

    }
    private void RecoverOne() {
        if (HPOne <= 0&& HPTwo<=0)
        {
            isDefeat = true;          
        }
        else {
            HPOne--;
            GameObject go = Instantiate(born, new Vector3(-2, -8 - 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayerOne = true;
            isDeadOne = false;
        }
    }
    private void RecoveTwo()
    {
        if (HPTwo <= 0)
        {
            isDefeat = true;
        }
        else
        {
            HPTwo--;
            GameObject go = Instantiate(born, new Vector3(2, -8 - 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayerTwo = true;
            isDeadTwo = false;
        }
    }

    private void ReturnToMain() {
        SceneManager.LoadScene(0);
}

}
