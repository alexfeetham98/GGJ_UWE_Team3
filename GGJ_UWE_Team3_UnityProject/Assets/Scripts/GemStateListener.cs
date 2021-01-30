using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStateListener : MonoBehaviour
{
    [SerializeField] private GEMS activatingGem;
    public bool isActive;

    void Start()
    {
        isActive = false;
    }
    
    void Update()
    {
        if (GemStateController._i.gemState == activatingGem)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }
}
