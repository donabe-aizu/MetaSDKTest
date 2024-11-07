using System.Collections;
using Unio;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using Image = UnityEngine.UI.Image;

public class LoadImage : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    CustomSampler _sampler;

    private string filepath = Application.dataPath + "/Image/donabe.png";
  
    void Start ()
    {
        // 事前にCustomSamplerを生成しておく必要あり
        _sampler = CustomSampler.Create("Unio");

        for (int i = 0; i < 50; i++)
        {
            StartCoroutine(GetTexture());
        }
    }
    
    private void LoadImageByFileStream()
    {
        var fileData = NativeFile.ReadAllBytes(filepath);
        Texture2D texture = new Texture2D(1, 1);
        texture.name = "SystemIO";
        texture.LoadRawTextureData(fileData);
    }
    
    private void LoadImageByUnio()
    {
        var fileData = NativeFile.ReadAllBytes(filepath);
        Texture2D texture = new Texture2D(1, 1,TextureFormat.RGBA32,1,false);
        texture.name = "Unio";
        texture.LoadRawTextureData(fileData);
    }
    
    IEnumerator GetTexture() {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://placehold.jp/150x150.png",false);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            myTexture.name = "LoadImage";
            Sprite sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            _image.sprite = sprite;
        }
    }
}
