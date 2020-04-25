using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    Vector3 lastpos;
    Vector3 scale;
    Vector3 pos;
    public GameObject player;
    void Start()
    {
        lastpos = transform.position;
        InvokeRepeating("spawing", 1f, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -4)
        {
            CancelInvoke("spawing");

        }
    }

    public void platform_on_x()
    {
        scale = platform.transform.localScale;

        pos = lastpos + new Vector3( scale.x + 0, 0,0);
        Instantiate(platform,pos,Quaternion.identity);
        lastpos = pos;
    }
    public void platform_on_z()
    {
        scale = platform.transform.localScale;

        pos = lastpos + new Vector3(0 , 0, scale.z);
        Instantiate(platform, pos, Quaternion.identity);
        lastpos = pos;
    }
    public void spawing()
    {
        int x;
        x = Random.Range(1, 100);
        if(x%2==0)
        {
            platform_on_x();
        }
        if(x%2!=0)
        {
            platform_on_z();
        }
    }

}
