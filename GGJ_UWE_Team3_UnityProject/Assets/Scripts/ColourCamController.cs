using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ColourCamController : MonoBehaviour
{
    private Camera colourCam;

    private void Awake()
    {
        colourCam = GetComponent<Camera>();
        colourCam.cullingMask = LayerMask.GetMask("All Realms");
    }

    void Update()
    {
        switch (GemStateController._i.gemState)
        {
            case GEMS.NATURE:
                colourCam.cullingMask = LayerMask.GetMask("Nature Realm", "All Realms", "UI");
                break;
            case GEMS.FROST:
                colourCam.cullingMask = LayerMask.GetMask("Frost Realm", "All Realms", "UI");
                break;
            case GEMS.FLAME:
                colourCam.cullingMask = LayerMask.GetMask("Flame Realm", "All Realms", "UI");
                break;
            case GEMS.SHADOW:
                colourCam.cullingMask = LayerMask.GetMask("Shadow Realm", "All Realms", "UI");
                break;
            case GEMS.NONE:
                colourCam.cullingMask = LayerMask.GetMask("Common Realm", "All Realms", "UI");
                break;
            default:
                Debug.Log("Unkown Active Gem");
                break;

        }
    }

           
     
     
}
