using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpin : MonoBehaviour
{
    public float spinSpeed = 100.0f;
    private float rotSpin = 0.0f;
   // private Quaternion spinVector = new Quaternion(0.0f, 0, 0, 1);

    void Update()
    {
        transform.localEulerAngles =  new Vector3(0, rotSpin , 0);
        rotSpin+=spinSpeed;      
    }
}
