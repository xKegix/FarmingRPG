using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crop : MonoBehaviour
{
    // reference to crop being grown.
    private CropData curCrop;

    // day crop planted.
    private int plantDay;

    // days last watered;
    private int daysSinceLastWatered;


    public SpriteRenderer sr;

    // trigger event on.
    public static event UnityAction<CropData> onPlantCrop;
    public static event UnityAction<CropData> onHarvestCrop;

    // crop plant.
    public void Plant(CropData crop)
    {
        curCrop = crop;
        plantDay = GameManager.instance.curDay;
        daysSinceLastWatered = 1;
        UpdateCropSprite();

        onPlantCrop?.Invoke(crop);
    }

    // check new day.
    public void NewDayCheck()
    {
        daysSinceLastWatered++;

        if(daysSinceLastWatered > 3)
        {
            Destroy(gameObject);
        }

        UpdateCropSprite();
    }

    // update sprite.
    void UpdateCropSprite()
    {
        int cropProg = CropProgress();

        // if crop still growing update spirite to grow progress.
        if(cropProg < curCrop.daysToGrow)
        {
            sr.sprite = curCrop.growProgressSprites[cropProg];
        }
        else
        {
            sr.sprite = curCrop.readyToHarvestSprite;
        }
    }

    public void Water()
    {
        daysSinceLastWatered = 0;
    }

    public void Harvest()
    {
        // can harvest? call function on current crop.
        if (CanHarvest())
        {
            onHarvestCrop?.Invoke(curCrop);
            Destroy(gameObject);
        }
    }

    // show days since planted.
    int CropProgress()
    {
        return GameManager.instance.curDay - plantDay;
    }

    public bool CanHarvest()
    {
        return CropProgress() >= curCrop.daysToGrow;
    }
}
