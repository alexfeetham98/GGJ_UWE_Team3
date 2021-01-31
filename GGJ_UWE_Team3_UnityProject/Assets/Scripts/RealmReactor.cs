using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmReactor : BaseReaction
{
    [SerializeField] private GameObject[] textureLayers;

    private void Awake()
    {
        foreach (GameObject textureLayer in textureLayers)
        {
            textureLayer.SetActive(false);
        }
    }

    public override void Reaction()
    {
        foreach (GameObject textureLayer in textureLayers)
        {
            textureLayer.SetActive(true);
        }
    }

    public override void ResetReaction()
    {
        foreach (GameObject textureLayer in textureLayers)
        {
            textureLayer.SetActive(false);
        }
    }
}
