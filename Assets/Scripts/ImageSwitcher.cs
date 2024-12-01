using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Collections.Generic;

public class ImageSwitcher : MonoBehaviour
{
    public objectsSet objSet;
    public Image image;
    public Image uiImage; //礶いUI瓜ボ

    public List<Color> imageColor = new List<Color>(); //﹚︹布计秖㎝肅︹

    void Start()
    {
    }


    //ち传sprite
    public void SwitchToNextSprite()
    {
        if (objSet.spritesArray == null || objSet.spritesArray.Count == 0)
            return;

        objSet.currentSpriteIndex = (objSet.currentSpriteIndex + 1) % objSet.spritesArray.Count;
        image.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
        uiImage.sprite = objSet.spritesArray[objSet.currentSpriteIndex];

    }

    //ち传sprite
    public void SwitchToPreviousSprite()
    {
        if (objSet.spritesArray == null || objSet.spritesArray.Count == 0)
            return;

        objSet.currentSpriteIndex = (objSet.currentSpriteIndex - 1 + objSet.spritesArray.Count) % objSet.spritesArray.Count;
        image.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
        uiImage.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
    }

    //ち传color
    public void SwitchColor(int num)
    {
        image.color = imageColor[num];
        uiImage.color = imageColor[num];
    }
}
