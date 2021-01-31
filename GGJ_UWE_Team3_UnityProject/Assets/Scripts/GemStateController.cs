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
    public GameObject WaterSound;
    public GameObject LavaSound;
    public GameObject RockSlide;
    public GameObject Freeze;
    public ParticleSystem fire;

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
        if (gemState == GEMS.FROST)
        {
            blueWalls.SetActive(false);
            Freeze.SetActive(true);
        }
        else if (gemState != GEMS.FROST)
        {
            blueWalls.SetActive(true);
            Freeze.SetActive(false);           
        }

        if (gemState == GEMS.NATURE)
        {
            greenWalls.SetActive(false);
            WaterSound.SetActive(true);
        }
        else if (gemState != GEMS.NATURE)
        {
            greenWalls.SetActive(true);
            WaterSound.SetActive(false);           
        }

        if (gemState == GEMS.FLAME)
        {
            redWalls.SetActive(false);
            LavaSound.SetActive(true);
            fire.Play();
        }
        else if (gemState != GEMS.FLAME)
        {
            redWalls.SetActive(true);
            LavaSound.SetActive(false);
            fire.Stop();
        }

        if (gemState == GEMS.SHADOW)
        {
            purpleWalls.SetActive(false);
            RockSlide.SetActive(true);
        }
        else if (gemState != GEMS.SHADOW)
        {
            purpleWalls.SetActive(true);
            RockSlide.SetActive(false);     
        }
    }
}
