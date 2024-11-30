using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Collections;

public class hairSwitcher : MonoBehaviour
{
    public Image hairimage; // Unity UI Image�ե�A�Ω���ܹϤ�

    // �s�x�Ҧ��n��ܪ�Sprite���}�C
    private Sprite[] spritesHair;

    private int currentSpriteIndex = 0; // ��e��ܪ�Sprite������

    void Start()
    {
        LoadSpritesFromStreamingAssetsfHairs();
    }

    void LoadSpritesFromStreamingAssetsfHairs()
    {
        string streamingAssetsPath = Application.streamingAssetsPath;
        streamingAssetsPath = Path.Combine(streamingAssetsPath, "hairs");

        string[] imagePaths = Directory.GetFiles(streamingAssetsPath, "*.png");

        spritesHair = new Sprite[imagePaths.Length];
        StartCoroutine(LoadSprites(imagePaths));
    }

    IEnumerator LoadSprites(string[] imagePaths)
    {
        int loadedCount = 0;

        for (int i = 0; i < imagePaths.Length; i++)
        {
            string filePath = "file://" + imagePaths[i];
            yield return StartCoroutine(LoadSpriteFromFile(filePath, i, () =>
            {
                loadedCount++;
                // �Ҧ��Ϥ����J������
                if (loadedCount == imagePaths.Length && spritesHair.Length > 0)
                {
                    // �]�m��ܪ��Ϥ�
                    hairimage.sprite = spritesHair[currentSpriteIndex];
                }
            }));
        }
    }

    IEnumerator LoadSpriteFromFile(string filePath, int index, System.Action onLoaded)
    {
        // �ϥ� UnityWebRequest �Ӹ��J�Ϥ�
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(filePath);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)uwr.downloadHandler).texture;
            spritesHair[index] = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        }
        else
        {
            Debug.LogError("Failed to load sprite at path: " + filePath);
        }

        // �I�s���J�����^��
        onLoaded?.Invoke();
    }

    public void SwitchToNextSprite()
    {
        if (spritesHair == null || spritesHair.Length == 0)
            return;

        currentSpriteIndex = (currentSpriteIndex + 1) % spritesHair.Length;
        hairimage.sprite = spritesHair[currentSpriteIndex];
    }

    public void SwitchToPreviousSprite()
    {
        if (spritesHair == null || spritesHair.Length == 0)
            return;

        currentSpriteIndex = (currentSpriteIndex - 1 + spritesHair.Length) % spritesHair.Length;
        hairimage.sprite = spritesHair[currentSpriteIndex];
    }

    public void SwitchToSprite(int index)
    {
        if (spritesHair == null || spritesHair.Length == 0 || index < 0 || index >= spritesHair.Length)
            return;

        currentSpriteIndex = index;
        hairimage.sprite = spritesHair[currentSpriteIndex];
    }
}