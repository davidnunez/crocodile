using UnityEngine;
using System.Collections;

public class alligator : MonoBehaviour {
	public GameObject bottom_jaw;
	public GameObject top_jaw;
	// Use this for initialization
	void Start () {
		bottom_jaw = transform.Find("Bottom Jaw").gameObject;
		top_jaw = transform.Find ("Top Jaw").gameObject;
		StartCoroutine("LoopAnimateMouthOpenClose");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator LoopAnimateMouthOpenClose() {
		while (true) {
		Debug.Log("LoopAnimateMouthOpenClose");
		AnimateMouthOpenClose();
		yield return new WaitForSeconds(2.5f);
		}
	}
	
	void AnimateMouthOpenClose() {
		iTween.RotateTo(bottom_jaw, iTween.Hash("z", 0.0f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));	
		iTween.RotateTo(bottom_jaw, iTween.Hash("z", -12.0f, "delay", 0.25f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));	

	}
}
