using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GEMS
{
    NONE,
    NATURE,
    FROST,
    FLAME,
    SHADOW,
}

public class GemStateController : MonoBehaviour
{
    public GameObject blueWalls;
    public GameObject greenWalls;
    public GameObject redWalls;
    public GameObject purpleWalls;

    public GEMS gemState;

    public static GemStateController _i { get; private set; }

    private void Awake()
    {
        if (_i == null)
        {
            _i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gemState = GEMS.NONE;
    }
    
    void Update()
    {
        //if (gemState == GEMS.FROST)
        //{
        //    blueWalls.SetActive(false);
        //}
        //else if (gemState != GEMS.FROST)
        //{
        //    blueWalls.SetActive(true);
        //}

        //if (gemState == GEMS.NATURE)
        //{
        //    greenWalls.SetActive(false);
        //}
        //else if (gemState != GEMS.NATURE)
        //{
        //    greenWalls.SetActive(true);
        //}

        //if (gemState == GEMS.FLAME)
        //{
        //    redWalls.SetActive(false);
        //}
        //else if (gemState != GEMS.FLAME)
        //{
        //    redWalls.SetActive(true);
        //}

        //if (gemState == GEMS.SHADOW)
        //{
        //    purpleWalls.SetActive(false);
        //}
        //else if (gemState != GEMS.SHADOW)
        //{
        //    purpleWalls.SetActive(true);
        //}
    }
}
