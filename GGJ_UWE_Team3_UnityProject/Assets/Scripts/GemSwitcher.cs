using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GemSwitcher : MonoBehaviour
{
    [SerializeField] private RectTransform gemWheel;
    [SerializeField] private RectTransform[] slots;
    [SerializeField] private Sprite natureGemSprite;
    [SerializeField] private Sprite frostGemSprite;
    [SerializeField] private Sprite flameGemSprite;
    [SerializeField] private Sprite shadowGemSprite;
    [SerializeField] private Material solidMat;

    private Inventory inv;
    private bool canSwitch;
    [SerializeField] private int selectedGemIndex;
    [SerializeField] private int currentUIGemIndex;
    private Vector3 selectedSlotScale;
    private Vector3 nonSelectedSlotScale;
    private float lerpScaler;
    [SerializeField] private float lerpScalerSpeed;
    private bool needToLoadUI;
    private bool hasLoadedUI;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
        canSwitch = false;
        selectedGemIndex = -1;
        currentUIGemIndex = -1;
        selectedSlotScale = new Vector3(0.26f, 0.26f, 0.26f);
        nonSelectedSlotScale = new Vector3(0.21f, 0.21f, 0.21f);
        lerpScaler = 0;
        needToLoadUI = false;
        hasLoadedUI = false;
    }

    private void Update()
    {
        UpdateGemVisuals();

        CheckIfCanSwitch();
    }

    private void UpdateLerpScaler()
    {
        if (lerpScaler < 1)
            lerpScaler += 1 * lerpScalerSpeed * Time.deltaTime;
        if (lerpScaler >= 1)
            lerpScaler = 1;
    }

    public void AddGemToUI()
    {
        selectedGemIndex = inv.gemInv.Count - 1;
        GemStateController._i.gemState = inv.gemInv[inv.gemInv.Count - 1];
        gemWheel.Rotate(Vector3.forward, 90); //* (inv.gemInv.Count - (selectedGemIndex + 1)));

        slots[selectedGemIndex].Find("Gem Icon").GetComponent<Image>().sprite =
            GetGemImage(inv.gemInv[inv.gemInv.Count - 1]);
        slots[selectedGemIndex].Find("Gem Icon").GetComponent<Image>().material = solidMat;

        hasLoadedUI = false;
    }

    private Sprite GetGemImage(GEMS gem)
    {
        switch (gem)
        {
            case GEMS.NATURE:
                return natureGemSprite;
            case GEMS.FROST:
                return frostGemSprite;
            case GEMS.FLAME:
                return flameGemSprite;
            case GEMS.SHADOW:
                return shadowGemSprite;
            default:
                return null;
        }
    }

    private void UpdateGemVisuals()
    {
        if (inv.gemInv.Count == 0)
        {
            //selectedGemIndex = -1;

            // Show empty UI wheel
        }
        else if (inv.gemInv.Count > 0)
        {
            // Populate wheel with collected gems
        }

        // Updating zoom selection based on gem count
        if (currentUIGemIndex != selectedGemIndex && !hasLoadedUI)
        {
            needToLoadUI = true;
            UpdateLerpScaler();

            if (needToLoadUI)
            {
                if (selectedGemIndex >= 0)
                slots[selectedGemIndex].localScale = Vector3.Lerp(nonSelectedSlotScale, selectedSlotScale, lerpScaler);
                if (currentUIGemIndex >= 0)
                slots[currentUIGemIndex].localScale = Vector3.Lerp(selectedSlotScale, nonSelectedSlotScale, lerpScaler);
            }
            if (lerpScaler == 1)
            {
                needToLoadUI = false;
                hasLoadedUI = true;
                lerpScaler = 0;
                currentUIGemIndex = selectedGemIndex;
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
                GemStateController._i.gemState = inv.gemInv[selectedGemIndex];

                gemWheel.Rotate(Vector3.forward, 90);
                hasLoadedUI = false;
            }
            //else
            //{
            //    selectedGemIndex = 0;
            //}

            // Update gemstate
            
        }
        else if (value.Get<float>() < 0 && canSwitch)
        {
            // Rotate to left gem by 1
            if (selectedGemIndex != 0)
            {
                selectedGemIndex -= 1;
                GemStateController._i.gemState = inv.gemInv[selectedGemIndex];

                gemWheel.Rotate(Vector3.forward, -90);
                hasLoadedUI = false;
            }
            //else
            //{
            //    selectedGemIndex = inv.gemInv.Count - 1;
            //}

            // Update gemstate
            
        }
    }

    private void OnGemLongSwitch(InputValue value)
    {

    }
}
