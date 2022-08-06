using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int curDay;
    public int money;
    public int cropInventory;

    // which crop currently wanting to plant.
    public CropData selectedCropToPlant;

    // New day when clicked.
    public event UnityAction onNewDay;

    // Singleton - globally accessible class that exists in the scene, but once.
    public static GameManager instance;

    void OnEnable()
    {
        Crop.onPlantCrop += OnPlantCrop;
        Crop.onHarvestCrop += OnHarvestCrop;
    }

    void OnDisable()
    {
        Crop.onPlantCrop -= OnPlantCrop;
        Crop.onHarvestCrop -= OnHarvestCrop;
    }


    void Awake()
    {
        // if old world exists destroy, create new world.
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // called when next day.
    public void SetNextDay()
    {

    }

    // substract crop from bag.
    public void OnPlantCrop (CropData crop)
    {

    }

    // sell crop and give money.
    public void OnHarvestCrop (CropData crop)
    {

    }

    // crop wanting to be purchased.
    public void PurchaseCrop (CropData crop)
    {

    }

    // able to plant or not?
    public bool CanPlantCrop (CropData crop)
    {
        return true;
    }

    // buy crop button.
    public void OnBuyCropButtom (CropData crop)
    {

    }

    // update text stats text on screen.
    void UodateStatsText ()
    {

    }
}
