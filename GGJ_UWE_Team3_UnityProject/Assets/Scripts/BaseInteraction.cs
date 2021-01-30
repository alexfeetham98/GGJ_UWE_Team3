using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteraction : MonoBehaviour
{
    private GemStateListener listener;

    private bool hasReacted;

    void Start()
    {
        listener = GetComponent<GemStateListener>();
        hasReacted = false;
    }
    
    void Update()
    {
        if (listener.isActive && !hasReacted)
        {
            hasReacted = true;
            Reaction();
        }
        else if (!listener.isActive)
        {
            hasReacted = false;
            Reset();
        }
    }

    private void Reaction()
    {
        // Write your reaction code here
        // Example, flame gem evaporating water
    }

    private void Reset()
    {
        // Write your reset code here
        // Example, bringing the water back into existence
    }
}
