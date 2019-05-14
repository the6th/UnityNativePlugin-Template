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

        Invoke("Test", 2);
    }

    void Test()
    {
        var msg = "Plugin load..";
        textMesh.text = msg;
        Debug.Log(msg);


        NativePluginSample.HogeFunction();
        var i = NativePluginSample.FugaFunction(0);

        msg = string.Format("FugaFunction \r\n returns  \r\n \"{0}\"", i);
        Debug.Log(msg);
        textMesh.text = msg;

    }

}
