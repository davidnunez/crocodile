using UnityEngine;
using System.Collections;

public class waveBehavior : MonoBehaviour {
	
	public float dx;
	public float dy;
	public float time;
	// Use this for initialization
	void Start () {
		iTween.MoveBy (gameObject, iTween.Hash("x", dx,  "time", time, "easetype", "easeInOutSine", "looptype", "pingpong"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
