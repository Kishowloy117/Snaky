using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uimanager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text tx;
    public GameObject bt;
    public Text score_show;
    public GameObject retry_bt;
    public GameObject pause_bt;
    player pl;
    public GameObject exit_bt;
   
    void Start()
    {
        bt.SetActive(false);
        Application.targetFrameRate = 60;
        score_show.enabled = false;
        retry_bt.SetActive(false);
        pl = gameObject.GetComponent<player>();
        exit_bt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            tx.enabled = false;
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            bt.SetActive(true);
            pause_bt.SetActive(false);
            Debug.Log("back button");
        }
    }
    public void pause()

    {
        Time.timeScale = 0f;
        bt.SetActive(true);
        pause_bt.SetActive(false);
        
    }
    public void play_again()
    {
        Time.timeScale = 1f;
        bt.SetActive(false);
        pause_bt.SetActive(true);
        Debug.Log("working");
        
    }
    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void exit()
    {
        Application.Quit();
    }
}
