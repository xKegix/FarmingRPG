using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : MonoBehaviour
{
    // private Crop curCrop;
    // prefab instantiated on top of tile.
    public GameObject cropPrefab;

    public SpriteRenderer sr;
    public bool tilled;

    [Header("Sprites")]
    public Sprite grassSprite;
    public Sprite tilledSprite;
    public Sprite waterTilledSprite;


    private void Start()
    {
        sr.sprite = grassSprite;
    }

    public void Interact()
    {
        Debug.Log("Interacted!");
    }
}
