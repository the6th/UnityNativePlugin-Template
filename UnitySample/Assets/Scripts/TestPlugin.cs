using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlugin : MonoBehaviour
{

    TextMesh textMesh;

    // Use this for initialization
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();

        Invoke("Test", 1);
    }

    void Test()
    {
        var msg = "Plugin load..";
        textMesh.text = msg;
        Debug.Log(msg);
            

        NativePluginSample.Func1();
        var i = NativePluginSample.Func2(9);

        msg = string.Format("FugaFunction \r\n returns  \r\n \"{0}\"", i);
        Debug.Log(msg);
        textMesh.text = msg;

        ZstdTest();

    }

    void ZstdTest()
    {
        gameObject.AddComponent<ZSTDTest>();
    }

}
