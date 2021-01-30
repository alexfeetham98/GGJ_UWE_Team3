using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ColourActivation : MonoBehaviour
{
  public Camera cam;
    public List<Vector3> tileWorldLocations;
    public Tilemap tilemap;
    public GEMS ActiveGem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        switch (ActiveGem)
        {
            case GEMS.FLAME:
                cam.cullingMask = LayerMask.GetMask("FLAME", "AlwaysON");
                break;
            case GEMS.FROST:
                cam.cullingMask = LayerMask.GetMask("FROST", "AlwaysON");
                break;
            case GEMS.NATURE:
                cam.cullingMask = LayerMask.GetMask("NATURE", "AlwaysON");
                break;
            case GEMS.SHADOW:
                cam.cullingMask = LayerMask.GetMask("SHADOW", "AlwaysON");
                break;
            case GEMS.NONE:
                cam.cullingMask = LayerMask.GetMask("Nothing");
                break;
            default:
                Debug.Log("Unkown Active Gem");
                break;

        }
    }

           
     
     
}
