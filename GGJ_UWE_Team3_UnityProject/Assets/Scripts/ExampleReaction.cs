using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleReaction : BaseReaction
{
    [Header("Reaction Variables")]
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material defaultMat;

    public override void Reaction()
    {
        // Example reaction
        gameObject.GetComponent<SpriteRenderer>().material = activatedMat;
    }

    public override void ResetReaction()
    {
        // Example reset
        gameObject.GetComponent<SpriteRenderer>().material = defaultMat;
    }
}
