using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class boost_gauge : MonoBehaviour
{
 
    public Image image;
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
 
        if (MS.CompareTag("movable"))
        {
            image.fillAmount -= Time.deltaTime/4;

            if (image.fillAmount == 0)
            {
                MS.tag = "cant_move";
                lapsetime = 0.0f;
            }
        }
        else if (MS.CompareTag("cant_move"))
        {
            lapsetime += Time.deltaTime;
            
            if(lapsetime >= 4)
            {
                MS.tag = "movable";
                image.fillAmount = 1;
            }
        }

        if (MS.CompareTag("on_floor"))
        {
                MS.tag = "cant_move";
                lapsetime = 0.0f;
        }
 
 
    }
}