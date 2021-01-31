using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GemSwitcher : MonoBehaviour
{
    private Inventory inv;
    private bool canSwitch;
    [SerializeField] private int selectedGemIndex;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
        canSwitch = false;
        selectedGemIndex = -1;
    }

    private void Update()
    {
        UpdateGemVisuals();

        CheckIfCanSwitch();
    }

    private void UpdateGemVisuals()
    {
        if (inv.gemInv.Count == 0)
        {
            selectedGemIndex = -1;

            // Show empty UI wheel
        }
        else if (inv.gemInv.Count > 0)
        {
            // Populate wheel with collected gems
        }

        // Updating selection based on gem count
        if (inv.gemInv.Count == 1)
        {
            selectedGemIndex = 0;
        }
    }

    private void CheckIfCanSwitch()
    {
        if (inv.gemInv.Count > 1 && !canSwitch)
        {
            canSwitch = true;
        }
        else if (inv.gemInv.Count == 0 && canSwitch)
        {
            canSwitch = false;
        }
    }

    private void OnGemInstantSwitch(InputValue value)
    {
        if (value.Get<float>() > 0 && canSwitch)
        {
            // Rotate to right gem by 1
            if (selectedGemIndex + 1 != inv.gemInv.Count)
            {
                selectedGemIndex += 1;
            }
            else
            {
                selectedGemIndex = 0;
            }
        }
        else if (value.Get<float>() < 0 && canSwitch)
        {
            // Rotate to left gem by 1
            if (selectedGemIndex != 0)
            {
                selectedGemIndex -= 1;
            }
            else
            {
                selectedGemIndex = inv.gemInv.Count - 1;
            }
        }
    }

    private void OnGemLongSwitch(InputValue value)
    {

    }
}
