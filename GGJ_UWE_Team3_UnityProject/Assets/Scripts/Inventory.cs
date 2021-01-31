using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<GEMS> gemInv = new List<GEMS>();

    //List<ITEMS> itemInv = new List<ITEMS>();
    //List<WEAPONS> weaponInv = new List<WEAPONS>();

    public void pickupGem(GEMS gem)
    {
        gemInv.Add(gem);
    }
}
