using System.Collections;
using System.Collections.Generic;
using Unio;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Profiling;

public class LoadImage : MonoBehaviour
{
    CustomSampler _sampler;

    private string filepath = Application.dataPath + "/Image/donabe.png";
  
    void Start ()
    {
        // 事前にCustomSamplerを生成しておく必要あり
        _sampler = CustomSampler.Create("Unio");
        
        _sampler.Begin();
        for (int i = 0; i < 50; i++)
        {
            LoadImageByUnio();
        }
        _sampler.End();
    }
    
    private void LoadImageByFileStream()
    {
        var fileData = System.IO.File.ReadAllBytes(filepath);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(fileData);
    }
    
    private void LoadImageByUnio()
    {
        var fileData = NativeFile.ReadAllBytes(filepath);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadRawTextureData(fileData);
    }
}
