using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Settings
{
    public static string GeneratePath(string fileName)
    {
        string filePath = fileName;
#if UNITY_EDITOR
        filePath = Application.dataPath + "/StreamingAssets/" + fileName;
#elif UNITY_IPHONE
        filePath = Application.dataPath +"/Raw/"+fileName;  
#elif UNITY_ANDROID
        filePath = "jar:file://" + Application.dataPath + "!/assets/"+fileName;  
#else
        filePath = Application.dataPath + "/StreamingAssets/" + fileName;
#endif
        return filePath;
    }
}