using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Collections;

public class ImageSwitcher : MonoBehaviour
{
    public objectsSet objSet;
    public Image image;
    public Image uiImage; //在畫面中UI的圖示

    void Start()
    {
        
    }


    //切換至下一個sprite
    public void SwitchToNextSprite()
    {
        if (objSet.spritesArray == null || objSet.spritesArray.Count == 0)
            return;

        objSet.currentSpriteIndex = (objSet.currentSpriteIndex + 1) % objSet.spritesArray.Count;
        image.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
        uiImage.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
    }

    //切換至上一個sprite
    public void SwitchToPreviousSprite()
    {
        if (objSet.spritesArray == null || objSet.spritesArray.Count == 0)
            return;

        objSet.currentSpriteIndex = (objSet.currentSpriteIndex - 1 + objSet.spritesArray.Count) % objSet.spritesArray.Count;
        image.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
        uiImage.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
    }

    public void SwitchToSprite(int index)
    {
        if (objSet.spritesArray == null || objSet.spritesArray.Count == 0 || index < 0 || index >= objSet.spritesArray.Count)
            return;

        objSet.currentSpriteIndex = index;
        image.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
        uiImage.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
    }
}
