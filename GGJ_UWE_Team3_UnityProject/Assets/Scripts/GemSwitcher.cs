using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GemSwitcher : MonoBehaviour
{
    [SerializeField] private RectTransform gemWheel;
    [SerializeField] private RectTransform slot1;
    [SerializeField] private RectTransform slot2;
    [SerializeField] private RectTransform slot3;
    [SerializeField] private RectTransform slot4;

    private Inventory inv;
    private bool canSwitch;
    [SerializeField] private int selectedGemIndex;
    private Vector3 selectedSlotScale;
    private Vector3 nonSelectedSlotScale;
    private bool updatingLerpScaler;
    private float lerpScaler;
    [SerializeField] private float lerpScalerSpeed;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
        canSwitch = false;
        selectedGemIndex = -1;
        selectedSlotScale = new Vector3(0.26f, 0.26f, 0.26f);
        nonSelectedSlotScale = new Vector3(0.21f, 0.21f, 0.21f);
        updatingLerpScaler = false;
        lerpScaler = 0;
    }

    private void Update()
    {
        UpdateGemVisuals();

        CheckIfCanSwitch();
    }

    private void UpdateLerpScaler()
    {
        if (updatingLerpScaler && lerpScaler < 1)
        {
            lerpScaler += 0 * lerpScalerSpeed * Time.deltaTime;
        }
        else if (lerpScaler >= 1)
        {
            lerpScaler = 1;
            updatingLerpScaler = false;
        }

        if (!updatingLerpScaler)
        {
            lerpScaler = 0;
        }
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
            slot1.localScale = Vector3.Slerp(nonSelectedSlotScale, selectedSlotScale, lerpScaler);
            slot2.localScale = nonSelectedSlotScale;
            slot3.localScale = nonSelectedSlotScale;
            slot4.localScale = nonSelectedSlotScale;
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

            updatingLerpScaler = true;
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
