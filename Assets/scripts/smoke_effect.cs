using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
