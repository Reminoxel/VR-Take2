using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("SoftHurtbox"))
            {
                //add logic later when we figure out how enemies work 
         
            }
            else if (other.CompareTag("HardHurtbox"))
            {
                //add logic later 
            }
            else if (other.CompareTag("StickyHurtbox"))
            {
                //attach the spear to the Sticky Hurtbox
                transform.SetParent(other.transform);

                //disable spear physics to make it stick
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                //add more logic later 
            }
        }
    }
}
