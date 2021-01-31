using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseReaction : MonoBehaviour
{
    [SerializeField] private GEMS activatingGem;
    
    private bool isActive;
    private bool hasReacted;

    void Start()
    {
        isActive = false;
        hasReacted = false;
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

        if (isActive && !hasReacted)
        {
            hasReacted = true;
            Reaction();
        }
        else if (!isActive)
        {
            hasReacted = false;
            ResetReaction();
        }
    }

    public virtual void Reaction()
    {
        // Override to write your reaction code
        // Example, flame gem evaporating water
    }

    public virtual void ResetReaction()
    {
        // Override to write your reaction reset code here
        // Example, bringing the water back into existence
    }
}
