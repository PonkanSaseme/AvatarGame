using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "myCustom", menuName = "objectsSet")]

public class objectsSet : ScriptableObject
{
    public List<Sprite> spritesArray = new List<Sprite>(); //�Ҧ��Ӫ���sprite
    public string iconName; //�Ӫ��󪺦W��
    public int currentSpriteIndex = 0; //�w�]�_�l����
}
