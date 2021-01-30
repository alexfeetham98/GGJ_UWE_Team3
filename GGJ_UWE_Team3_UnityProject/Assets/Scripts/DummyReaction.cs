using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyReaction : MonoBehaviour
{
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material defaultMat;

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
        // Example reaction
        gameObject.GetComponent<SpriteRenderer>().material = activatedMat;
    }

    private void Reset()
    {
        // Example reset
        gameObject.GetComponent<SpriteRenderer>().material = defaultMat;
    }
}
