using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Collections.Generic;

public class ImageSwitcher : MonoBehaviour
{
    public objectsSet objSet;
    public Image image;
    public Image uiImage; //�b�e����UI���ϥ�

    public List<Color> imageColor = new List<Color>(); //���w�Ⲽ�ƶq�M�C��

    void Start()
    {
    }


    //�����ܤU�@��sprite
    public void SwitchToNextSprite()
    {
        if (objSet.spritesArray == null || objSet.spritesArray.Count == 0)
            return;

        objSet.currentSpriteIndex = (objSet.currentSpriteIndex + 1) % objSet.spritesArray.Count;
        image.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
        uiImage.sprite = objSet.spritesArray[objSet.currentSpriteIndex];

    }

    //�����ܤW�@��sprite
    public void SwitchToPreviousSprite()
    {
        if (objSet.spritesArray == null || objSet.spritesArray.Count == 0)
            return;

        objSet.currentSpriteIndex = (objSet.currentSpriteIndex - 1 + objSet.spritesArray.Count) % objSet.spritesArray.Count;
        image.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
        uiImage.sprite = objSet.spritesArray[objSet.currentSpriteIndex];
    }

    //����color
    public void SwitchColor(int num)
    {
        image.color = imageColor[num];
        uiImage.color = imageColor[num];
    }
}
