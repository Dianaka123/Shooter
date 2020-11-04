using System;
using System.Collections;

using System.IO;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class JsonFile
{
    public float speed;
    public float health;
    public string fullName;
    public string base64Texture;
}
public class DownloadFiles : Editor
{
    [MenuItem("Tools/WebRequest")]
    public static void GetInformation()
    {
        var zipFileName = "settings.zip";
        string zipFilePath = Path.Combine(Application.persistentDataPath, zipFileName);
        if (File.Exists(zipFilePath))
        {
            File.Delete(zipFilePath);
        }
        
        string uri = "https://dminsky.com/settings.zip";
        UnityWebRequest uwr = UnityWebRequest.Get(uri);

        uwr.downloadHandler = new DownloadHandlerFile(zipFilePath);

        var asyncRequest = uwr.SendWebRequest();

        asyncRequest.completed += (request) =>
        {
            if (uwr.isHttpError || uwr.isNetworkError)
            {
                Debug.Log("Error");
            }
            else
            {
                JsonFile jsonFile = GetJsonFile(zipFilePath);
                if (jsonFile == null)
                {
                    return;
                }

                var player = GameObject.FindWithTag("Player");
                player.GetComponent<PlayerMoving>().speed = jsonFile.speed;
                
                var texture2D = GetTextureFromByte64(jsonFile.base64Texture);
                Debug.Log(texture2D);
                
                var planeMaterial = GameObject.FindWithTag("Plane")?.GetComponent<MeshRenderer>()?.sharedMaterial;
                Debug.Log(planeMaterial);
                planeMaterial.SetTexture("_MainTex", texture2D);
            }
        };
    }

    private static JsonFile GetJsonFile(string zipFilePath)
    {
        var newFolder = "Settings";
        var settingsPath = Path.Combine(Application.persistentDataPath, newFolder);
        string[] files;
        if (Directory.Exists(settingsPath))
        {
            files = Directory.GetFiles(settingsPath);
            foreach (var file in files)
            {
                File.Delete(file);
            }
            Directory.Delete(settingsPath);
        }
                
        ZipFile.ExtractToDirectory(zipFilePath, settingsPath);
                
        files = Directory.GetFiles(settingsPath);
        JsonFile result = null;
        if (files.Length != 0 )
        {
            var fileName = files[0];
            var data = File.ReadAllText(fileName);
                    
            result = JsonUtility.FromJson<JsonFile>(data);
        }

        return result;
    }

    private static Texture2D GetTextureFromByte64(string base64)
    {
        var texture = new Texture2D(2, 2);
        var bytes = Convert.FromBase64String(base64);
        
        texture.LoadImage(bytes);
        return texture;
    }
}
