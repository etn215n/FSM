using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour 
{
    private delegate void FunctionSelector();
    FunctionSelector a;

    private void Doa()
    {
        Debug.Log("a");
    }

    private void Dob()
    {
        Debug.Log("b");
    }

	void Start () 
    {
        a = Doa;
	}
	
	// Update is called once per frame
	void Update () 
    {
        a();

        if (Input.GetKey(KeyCode.B))
            a = Dob;
	}
}
