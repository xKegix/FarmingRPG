using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop Data", menuName = "New Crop Data")]
public class CropData : ScriptableObject
{
    // days to grow.
    public int daysToGrow;
    // array of crop growth sprites.
    public Sprite[] growProgressSprites;
    // ready to harvest sprite
    public Sprite readyToHarvestSprite;

    //  purchase price of crop.
    public int purchasePrice;
    //  sell price of crop.
    public int sellPrice;

}
