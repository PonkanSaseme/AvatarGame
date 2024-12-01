using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "myCustom", menuName = "objectsSet")]

public class objectsSet : ScriptableObject
{
    public List<Sprite> spritesArray = new List<Sprite>(); //所有該物件的sprite
    public string iconName; //該物件的名稱
    public int currentSpriteIndex = 0; //預設起始索引
}
