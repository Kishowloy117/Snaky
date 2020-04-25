using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Material platform_mat;
    public Color32 textColor32;
    int count = 0;
    void Start()
    {

        InvokeRepeating("change_color", 01f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void change_color()
    {
        count++;
        if(count%2!=0)
        {
            RandomizeTextColor1();
        }
        else if(count%2==0)
        {
            RandomizeTextColor2();
        }
    }


    void RandomizeTextColor1()
    {
        textColor32 = new Color32(
            75,7,38,       // B
           255);      // A
        platform_mat.color = textColor32;
    }
    void RandomizeTextColor2()
    {
        textColor32 = new Color32(
           153,101,21,       // B
           255);      // A
        platform_mat.color = textColor32;
    }
}
