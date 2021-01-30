using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private GEMS gemType;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Inventory inv = collision.gameObject.GetComponent<Inventory>();

            inv.pickupGem(gemType);

            Destroy(gameObject);
        }
    }
}
