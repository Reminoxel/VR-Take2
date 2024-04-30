using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightBlockerExpand : MonoBehaviour
{
    private Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 rate = new Vector3(1.0f, 1.0f, 1.0f);
    public int expandDelay = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    this.transform.localScale=scale; 


    if(Time.timeSinceLevelLoad>expandDelay){
        scale = scale + (0.1f*rate);
        if(Time.timeSinceLevelLoad>expandDelay*3){
            scale = scale + (1f*rate);
        }
        if(Time.timeSinceLevelLoad>20){
            Destroy(this.gameObject);
        }
    }
    

    }
}
