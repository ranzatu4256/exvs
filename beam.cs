using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour
{
    public GameObject MS;

    public float lapsetime;
 
    // Start is called before the first frame update
    void Start()
    {
        lapsetime = 0.0f;
    }
 
    // Update is called once per frame
    void Update()
    {
        Vector3 dirToGo = Vector3.zero;
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.velocity = Vector3.zero;
        
        if(this.CompareTag("attack"))
        {
            lapsetime += Time.deltaTime;
            dirToGo = transform.forward;
            
            if(lapsetime >= 2)
            {
                rBody.AddForce(dirToGo * 2.0f, ForceMode.VelocityChange);
            }

            if(lapsetime >= 3)
            {
                MS.tag = "movable";
            }

            if(lapsetime >= 14)
            {
                this.tag = "locked";
            }
        } 
        else if(this.CompareTag("locked"))
        {
            transform.rotation = MS.transform.rotation;
            this.transform.localPosition = MS.transform.position;

            if (MS.CompareTag("attack"))
            {
                lapsetime = 0.0f;
                this.tag = "attack";
                MS.tag = "attacking";
            }
        }
    }
}
