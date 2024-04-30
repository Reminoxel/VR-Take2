using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public GameObject hpVisual;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoDamage(){
        
        hpVisual.GetComponent<HPVisualManager>().takeDamage(); 
        
    }


}
