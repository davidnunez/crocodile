using UnityEngine;
using System.Collections;

public class TestLog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Funf.Log ("App Started", "true");
		Funf.Log ("\"key1\":1, \"key2\":\"value2\"");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}


