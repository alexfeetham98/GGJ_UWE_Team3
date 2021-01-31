using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : BaseReaction
{
    public GameObject poofSFX;

    public override void Reaction()
    {
        poofSFX.SetActive(true);
    }

    public override void ResetReaction()
    {
        poofSFX.SetActive(false);
    }
}
