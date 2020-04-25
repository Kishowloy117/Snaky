using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class game_manager : MonoBehaviour
{
    public Text high_score;
    public Color32 textColor32;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("highscore"))
        {
            int str = PlayerPrefs.GetInt("highscore");
            high_score.text="Highest Score:"+str;
        }
        else
        {
            high_score.text = "Highest Score: 0";
        }
        InvokeRepeating("RandomizeTextColor", .1f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        high_score.color = textColor32;
    }
    public void loadgame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void colorchange()
    {
        
    }
    void RandomizeTextColor()
    {
        textColor32 = new Color32(
            (byte)Random.Range(0, 255),        // R
            (byte)Random.Range(0, 255),        // G
            (byte)Random.Range(0, 255),        // B
           255);      // A
    }
}
