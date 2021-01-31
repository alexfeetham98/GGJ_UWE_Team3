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
    private bool needToLoadUIForSingle;
    private bool hasLoadedUIForSingle;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
        canSwitch = false;
        selectedGemIndex = -1;
        selectedSlotScale = new Vector3(0.26f, 0.26f, 0.26f);
        nonSelectedSlotScale = new Vector3(0.21f, 0.21f, 0.21f);
        updatingLerpScaler = false;
        lerpScaler = 0;
        needToLoadUIForSingle = false;
        hasLoadedUIForSingle = false;
    }

    private void Update()
    {
        UpdateLerpScaler();
        UpdateGemVisuals();

        CheckIfCanSwitch();
    }

    private void UpdateLerpScaler()
    {
        if (updatingLerpScaler && lerpScaler < 1)
        {
            lerpScaler += 1 * lerpScalerSpeed * Time.deltaTime;
        }
        else if (lerpScaler >= 1)
        {
            lerpScaler = 1;
            updatingLerpScaler = false;
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

        // Updating selection based on gem count of 1
        if (inv.gemInv.Count == 1 && !hasLoadedUIForSingle)
        {
            updatingLerpScaler = true;
            needToLoadUIForSingle = true;
            selectedGemIndex = 0;

            if (needToLoadUIForSingle)
            {
                slot1.localScale = Vector3.Lerp(nonSelectedSlotScale, selectedSlotScale, lerpScaler);
                //slot2.localScale = Vector3.Slerp(selectedSlotScale, nonSelectedSlotScale, lerpScaler);
                //slot3.localScale = Vector3.Lerp(selectedSlotScale, nonSelectedSlotScale, lerpScaler);
                //slot4.localScale = Vector3.Slerp(selectedSlotScale, nonSelectedSlotScale, lerpScaler);
            }
            if (lerpScaler == 1)
            {
                needToLoadUIForSingle = false;
                hasLoadedUIForSingle = true;
                lerpScaler = 0;
            }
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
