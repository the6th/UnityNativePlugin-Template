using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ZSTDTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Test();
    }

    void Test()
    {
        string text;
        TextAsset T = Resources.Load("File") as TextAsset;
        text = T.text;
        //text = File.ReadAllText("Assets/Resources/File.txt");

        //var textAsset = Resources.Load("File.txt") as TextAsset;

        Debug.Log("1:string:" + text);
        var bytes = System.Text.Encoding.UTF8.GetBytes(text);
        Debug.Log("2:bytes" + bytes.ToString());
        Debug.Log("3:bytes to string:" + System.Text.Encoding.UTF8.GetString(bytes));
        var compressed = ZSTD.Compress(bytes);
        Debug.Log("4:bytes Compredded to string:" + System.Text.Encoding.UTF8.GetString(compressed));
        var unCompressed = ZSTD.Decompress(compressed);
        Debug.Log("5:bytes unCompredded to string:" + System.Text.Encoding.UTF8.GetString(unCompressed));


        Debug.Log("Len:" + compressed.Length + ":" + unCompressed.Length);
        File.WriteAllText("Assets/Resources/out.txt", System.Text.Encoding.UTF8.GetString(unCompressed));
        //Debug.Log("3:bytes to string:" + System.Text.Encoding.ASCII.GetString(bytes));
    }
}
