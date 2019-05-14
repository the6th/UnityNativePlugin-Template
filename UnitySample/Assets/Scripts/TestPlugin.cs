using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlugin : MonoBehaviour {

    TextMesh textMesh;

	// Use this for initialization
	void Start () {

        textMesh = gameObject.GetComponent<TextMesh>();
        Test();
    }
	
    void Test()
    {
        Debug.Log("Plugin load..");


        NativePluginSample.HogeFunction();
        var i = NativePluginSample.FugaFunction(0);

        var msg = string.Format("FugaFunction \r\n returns  \r\n \"{0}\"", i);
        Debug.Log(msg);
        textMesh.text = msg;

    }

}
