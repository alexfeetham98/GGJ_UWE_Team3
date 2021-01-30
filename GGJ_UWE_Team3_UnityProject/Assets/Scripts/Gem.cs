using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private GEMS gemType;
    [SerializeField] private float bobHeight;
    [SerializeField] private float bobSpeed;

    private float bob;
    private bool bobGoingUp;

    private void Awake()
    {
        bob = 0;
        bobGoingUp = false;
    }

    private void Update()
    {
        // Flip bob direction
        if (bob >= bobHeight || bob <= 0)
        {
            bobGoingUp = !bobGoingUp;
        }

        // Move bob
        bob = bobGoingUp ? bob + bobSpeed * Time.deltaTime : bob - bobSpeed * Time.deltaTime;

        // Apply bob
        Vector3 spriteLocalPos = transform.Find("Sprite").localPosition;
        transform.Find("Sprite").localPosition =
            new Vector3(spriteLocalPos.x, 0 + bob, spriteLocalPos.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check to add gem to player inventory
        if (collision.gameObject.tag == "Player")
        {
            Inventory inv = collision.gameObject.GetComponent<Inventory>();

            inv.pickupGem(gemType);

            Destroy(gameObject);
        }
    }
}
