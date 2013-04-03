using UnityEngine;
using System.Collections;

public class RewardSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Drop() {
		iTween.MoveTo (gameObject, iTween.Hash ("y", 630.0f, "time", 0.5f, "easetype", "easeOutBounce"));	
	}
	
	public void Retract() {
		iTween.MoveTo (gameObject, iTween.Hash ("y", 1230.0f, "time", 0.5f, "easetype", "easeInSine"));	

	}
}
