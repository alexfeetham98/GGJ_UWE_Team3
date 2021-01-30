using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourActivation : MonoBehaviour
{
  public Camera cam;
   public bool red;
    public bool blue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(red)
        {
            cam.cullingMask = LayerMask.GetMask("Red", "AlwaysON");
            
        }
        else if(blue)
        {
            cam.cullingMask = LayerMask.GetMask("Blue", "AlwaysON");
        }
        else
        {
            cam.cullingMask = LayerMask.GetMask("Nothing");
        }
    }
}
