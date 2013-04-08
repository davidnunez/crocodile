using UnityEngine;
using System.Collections;

public class alligator : MonoBehaviour {
	public GameObject bottom_jaw;
	public GameObject top_jaw;
	public GameObject foot1;
	public GameObject foot2;
	public GameObject foot3;
	public GameObject foot4;
	public bool jumping = false;
	public RewardSprite rewardSprite;
	
	// Use this for initialization
	void Start () {
		bottom_jaw = transform.Find("Bottom Jaw").gameObject;
		top_jaw = transform.Find ("Top Jaw").gameObject;
		
		foot1 = transform.Find ("Foot 1").gameObject;
		foot2 = transform.Find ("Foot 2").gameObject;
		foot3 = transform.Find ("Foot 3").gameObject;
		foot4 = transform.Find ("Foot 4").gameObject;

		
		
		
//		StartCoroutine("LoopAnimateMouthOpenClose");
	}
	
	void OnEnable() {
    //    FingerGestures.OnFingerDown += FingerGestures_OnFingerDown;
	}
	void OnDisable() {
    //    FingerGestures.OnFingerDown -= FingerGestures_OnFingerDown;
	}	
	
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator LoopAnimateMouthOpenClose() {
		while (true) {
		Debug.Log("LoopAnimateMouthOpenClose");
//		AnimateMouthOpenClose();
		yield return new WaitForSeconds(2.5f);
		}
	}
	
	public void AnimateMouthOpenClose() {
		iTween.RotateTo(bottom_jaw, iTween.Hash("z", 0.0f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));	
		iTween.RotateTo(bottom_jaw, iTween.Hash("z", -12.0f, "delay", 0.25f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));	
	}
	
	public void JumpToPoint(float x, float y, bool swimOff) {
		StartCoroutine(DoJumpToPoint(x,y, swimOff));	
	}
	
	
	public void AnimateMouth(bool open, bool wide) {
		if (open) {
			iTween.RotateTo(bottom_jaw, iTween.Hash("z", 0.0f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));
			if (wide) {
				iTween.RotateTo(top_jaw, 	iTween.Hash("z", -20.0f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));	
			}
		} else {
			iTween.RotateTo(bottom_jaw, iTween.Hash("z", -12.0f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));	
			if (wide) {
				iTween.RotateTo(top_jaw, 	iTween.Hash("z", 0.0f, "time", 0.25f, "easetype", "easeInOutSine", "islocal", true));	
			}
		}
	}
	
	IEnumerator DoJumpToPoint(float x, float y, bool swimOff) {
		jumping = true;
		AnimateMouth(true, true);
		iTween.RotateTo (gameObject, iTween.Hash ("z", -45, "time", 1.0f, "easetype", "easeInOutSine"));
		iTween.MoveTo (gameObject, iTween.Hash ("x", x, "y", y, "time", 1.0f, "easetype", "easeInOutSine"));
		
		iTween.RotateTo (foot1, iTween.Hash ("z", 90, "time", 1.0f, "easetype", "easeInOutSine", "islocal", true));
		iTween.RotateTo (foot2, iTween.Hash ("z", 90, "time", 1.0f, "easetype", "easeInOutSine", "islocal", true));
		iTween.RotateTo (foot3, iTween.Hash ("z", 90, "time", 1.0f, "easetype", "easeInOutSine", "islocal", true));
		iTween.RotateTo (foot4, iTween.Hash ("z", 90, "time", 1.0f, "easetype", "easeInOutSine", "islocal", true));

		yield return new WaitForSeconds(0.75f);

		AnimateMouth(false,true);
		
		rewardSprite.Drop();
		
		yield return new WaitForSeconds(0.75f);
		
		
		
		iTween.MoveTo (gameObject, iTween.Hash ("x", 200, "y", -600.0f, "time", 1.0f, "easetype", "easeInOutSine"));
		iTween.RotateTo (gameObject, iTween.Hash ("z", 45, "time", 1.0f, "easetype", "easeInOutSine"));

		yield return new WaitForSeconds(0.5f);
		
		rewardSprite.Retract();
		
		yield return new WaitForSeconds(0.5f);

		iTween.RotateTo (gameObject, iTween.Hash ("z", 0, "time", 0f, "easetype", "easeInOutSine"));
		iTween.MoveTo (gameObject, iTween.Hash ("x", 1016.078f, "y", -600.0f, "time", 0f, "easetype", "easeInOutSine"));

		iTween.RotateTo (foot1, iTween.Hash ("z", 0, "time", 0f, "easetype", "easeInOutSine", "islocal", true));
		iTween.RotateTo (foot2, iTween.Hash ("z", 0, "time", 0f, "easetype", "easeInOutSine", "islocal", true));
		iTween.RotateTo (foot3, iTween.Hash ("z", 0, "time", 0f, "easetype", "easeInOutSine", "islocal", true));
		iTween.RotateTo (foot4, iTween.Hash ("z", 0, "time", 0f, "easetype", "easeInOutSine", "islocal", true));
		
		if (!swimOff) {
		
			yield return new WaitForSeconds(1.0f);
			iTween.MoveTo (gameObject, iTween.Hash ("x", 1016.078f, "y", 120.0f, "time", 1.0f, "easetype", "easeInOutSine"));

			yield return new WaitForSeconds(1.0f);
			jumping = false;
		} else {
			iTween.RotateTo (gameObject, iTween.Hash ("y", -180.0f, "z", -10.0f, "time", 0f, "easetype", "easeInOutSine"));
			iTween.MoveTo (gameObject, iTween.Hash ("x", 200.0f, "y", 120.0f, "time", 1.0f, "easetype", "easeInOutSine"));
			yield return new WaitForSeconds(1.0f);
			iTween.MoveTo (gameObject, iTween.Hash ("x", 1816.078f, "y", 120.0f, "time", 1.0f, "easetype", "easeInOutSine"));
			yield return new WaitForSeconds(1.0f);
			iTween.RotateTo (gameObject, iTween.Hash ("y", 0, "z", 0, "x", 0, "time", 0f, "easetype", "easeInOutSine"));
			yield return new WaitForSeconds(1.0f);
			jumping = false;
			
		}
		
	}

	
	void FingerGestures_OnFingerDown( int fingerIndex, Vector2 fingerPos ) {
		Debug.Log ("OnFingerDown: x=" + fingerPos.x + ", y=" + fingerPos.y);
		JumpToPoint(fingerPos.x, fingerPos.y, true);
		
		
	}

	
	
	// utility method to raycast into the scene from the input screen position, looking for a rigidbody
    GameObject PickGameObject( Vector2 screenPos )
    {
        Ray ray = Camera.main.ScreenPointToRay( screenPos );
        RaycastHit hit;

        if( !Physics.Raycast( ray, out hit ) )
            return null;
        return hit.collider.gameObject;
    }
	
	
	public void Dunk() {
		iTween.MoveTo (gameObject, iTween.Hash ("x", 1016.078f, "y", 0.0f, "time", 0.25f, "easetype", "easeInOutSine"));
		iTween.MoveTo (gameObject, iTween.Hash ("x", 1016.078f, "y", 120.0f, "time", 0.5f, "easetype", "easeInOutSine", "delay", 0.25f));

	}
}
