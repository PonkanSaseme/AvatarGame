using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Collections;

public class hairSwitcher : MonoBehaviour
{
    public Image hairimage; // Unity UI Image組件，用於顯示圖片

    // 存儲所有要顯示的Sprite的陣列
    private Sprite[] spritesHair;

    private int currentSpriteIndex = 0; // 當前顯示的Sprite的索引

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
                // 所有圖片載入完成後
                if (loadedCount == imagePaths.Length && spritesHair.Length > 0)
                {
                    // 設置顯示的圖片
                    hairimage.sprite = spritesHair[currentSpriteIndex];
                }
            }));
        }
    }

    IEnumerator LoadSpriteFromFile(string filePath, int index, System.Action onLoaded)
    {
        // 使用 UnityWebRequest 來載入圖片
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

        // 呼叫載入完成回調
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