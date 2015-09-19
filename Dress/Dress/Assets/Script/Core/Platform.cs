using System.ComponentModel.Design.Serialization;
using System.IO;
using UnityEngine;
using System.Collections;

public abstract class Platform
{
    private static Platform instance = null;

    protected Platform()
    {
        
    }

    public static Platform Instance()
    {
        if (instance == null)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                instance = new AndroidPlatform();
            }

            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                instance = new IPhonePlatform();
            }

            else
            {
                instance = new WindowPlatform();
            }
        }

        return  instance;
    }

    public virtual string GetSaveScreenShotPath()
    {
        return Application.persistentDataPath;
    }

    public abstract string GetStreamingAssetsPath(string fileName);

    public abstract string GetPersistentDataPath(string fileName);
}


public class WindowPlatform : Platform
{
    public override string GetStreamingAssetsPath(string filename)
    {
        return Application.dataPath + "/StreamingAssets" + filename;
    }

    public override string GetPersistentDataPath(string fileName)
    {
        string path = Application.dataPath;
        path = path.Substring(0, path.LastIndexOf( '/' ) );
        return Path.Combine(path, fileName);
    }
}

public class AndroidPlatform : Platform
{
    public override string GetSaveScreenShotPath()
    {
        return "../../../../DCIM/Camera";
    }

    public override string GetStreamingAssetsPath(string filename)
    {
        string strFilePath = Application.persistentDataPath + filename;
        Debug.Log("file://" + Application.dataPath + "!/assets" + filename);

        WWW wwwUrl = new WWW("jar:file://" + Application.dataPath + "!/assets" + filename);
        while (!wwwUrl.isDone) { }

        if (string.IsNullOrEmpty(wwwUrl.error) == false)
        {
            return "file not found";
        }

        File.WriteAllBytes(strFilePath, wwwUrl.bytes);

        return strFilePath;
    }

    public override string GetPersistentDataPath(string fileName)
    {
        string path = Application.persistentDataPath;
        path = path.Substring(0, path.LastIndexOf( '/' ) );
        return Path.Combine(path, fileName);
    }
}

public class IPhonePlatform : Platform
{
    public override string GetStreamingAssetsPath(string filename)
    {
        return Application.dataPath + "/Raw" + filename;
    }

    public override string GetPersistentDataPath(string fileName)
    {
        throw new System.NotImplementedException();
    }
}



//public void writeStringToFile( string str, string filename )
//{
//#if !WEB_BUILD
//    string path = pathForDocumentsFile( filename );
//    FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
//
//    StreamWriter sw = new StreamWriter( file );
//    sw.WriteLine( str );
//
//    sw.Close();
//    file.Close();
//#endif 
//}


// public string readStringFromFile( string filename)//, int lineIndex )
// {
// #if !WEB_BUILD
//     string path = pathForDocumentsFile( filename );
 
//     if (File.Exists(path))
//     {
//         FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
//         StreamReader sr = new StreamReader( file );
 
//         string str = null;
//         str = sr.ReadLine ();
 
//         sr.Close();
//         file.Close();
 
//         return str;
//     }
//     else
//     {
//         return null;
//     }
// #else
//     return null;
// #endif 
// }

// 파일쓰고 읽는넘보다 이놈이 핵심이죠
// public string pathForDocumentsFile( string filename ) 
// { 
//     if (Application.platform == RuntimePlatform.IPhonePlayer)
//     {
//         string path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
//         path = path.Substring( 0, path.LastIndexOf( '/' ) );
//         return Path.Combine( Path.Combine( path, "Documents" ), filename );
//     }
//     else if(Application.platform == RuntimePlatform.Android)
//     {
//         string path = Application.persistentDataPath; 
//         path = path.Substring(0, path.LastIndexOf( '/' ) ); 
//         return Path.Combine (path, filename);
//     } 
//     else 
//     {
//         string path = Application.dataPath; 
//         path = path.Substring(0, path.LastIndexOf( '/' ) );
//         return Path.Combine (path, filename);
//     }
// }