using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
   public Rigidbody rb;
    float speed = 8f;
    bool started = false;
    RaycastHit hit;
    int score = 0;
    bool scoring = false;
    public GameObject retry_bt;
    public GameObject pause_button;

    public Text tx;
    public Color32 textColor32;

    public Text score_show;
    bool ispaused = false;
    public GameObject exit_bt;
    public Text congo_text;
    public AudioClip backgroundMusic;
    public AudioClip song;
    AudioSource _audio;


    void Start()
    {
        // rb.GetComponent<Rigidbody>();
        InvokeRepeating("sppedincrease", 60f, 60f);
        Application.targetFrameRate = 60;
        _audio = GetComponent<AudioSource>();
        _audio.clip = backgroundMusic;

    }

    // Update is called once per frame
    void Update()
    {
        if (ispaused == false)
        {
            if (Input.mousePosition.y < (Screen.height - Screen.height / 2))
            {


                if (Input.GetMouseButtonDown(0))
                {
                    if (started == false)
                    {
                        rb.velocity = new Vector3(0, 0, speed);

                        started = true;
                        scoring = true;
                        

                    }
                    else
                    {
                        movement();
                        
                    }
                }
            }
        }
            if(scoring==true)
            {
                scoring = false;
                


            }
            if(transform.position.y<-4)
            {
                string str = "YOUR SCORE : " + score;
                
                scoring = false;
                rb.velocity = new Vector3(0, 0, 0);
                savescore();
                score_show.text = str;
                score_show.enabled = true;
                pause_button.SetActive(false);
                score_show.color = textColor32;
                InvokeRepeating("RandomizeTextColor", .1f, .1f);
                retry_bt.SetActive(true);
            exit_bt.SetActive(true);
                int x = PlayerPrefs.GetInt("highscore");
                Debug.Log(x);
            congo_text.color = textColor32;
            

               
            }
            
        
        if(!Physics.Raycast(transform.position,Vector3.down,1f))
        {
           
            if (rb.velocity.x > 0)
            {
                transform.position =transform.position+ new Vector3(.8f, 0, 0);
                rb.velocity = new Vector3(0, -5f, 0);
               
            }
            if (rb.velocity.z > 0)
            {
                transform.position =transform.position+ new Vector3(0, 0, .8f);
                rb.velocity = new Vector3(0, -5f, 0);
         
            }
        }
        if(pause_button.activeSelf)
        {
            ispaused = false;
        }
        if (!pause_button.activeSelf)
        {
            
            ispaused = true;
        }
        



    }

    public void movement()
    {
        if(rb.velocity.x>0)
        {
            rb.velocity = new Vector3(0, 0, speed);
            

        }
        else if(rb.velocity.z>0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
            
        }
    }
   public void sppedincrease()
    {
        if(speed<13)
        {
            if(speed==8)
            {
                speed = 10;
            }
            speed++;
        }
    }

    public void savescore()
    {
        if(PlayerPrefs.HasKey("highscore"))
        {
            if(score>PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
                congo_text.text="Congratulation Highest Score";
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "platform")
        {
            score++;
            tx.text = score.ToString();
            _audio.Play();
            if (score>80)
            {
                speed = 10;
                Debug.Log("Speed incresed");
            }
            if(score>200)
            {
                speed = 11;
            }
            if(score>400)
            {
                speed=12;
            }
        }
    }
    void RandomizeTextColor()
    {
        textColor32 = new Color32(
            (byte)Random.Range(0, 255),        // R
            (byte)Random.Range(0, 255),        // G
            (byte)Random.Range(0, 255),        // B
           255);      // A
    }
    public void touch_on()
    {
        ispaused = false;
    }
    public void touch_off()
    {
        ispaused = true;
    }

}
