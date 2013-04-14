using UnityEngine;
using System.Collections;

public class alligator : MonoBehaviour {
    public enum AlligatorColors {blue, green, pink, red, yellow};
	public AlligatorColors alligatorColor;
	
	public GameObject body;
	public GameObject bottom_jaw;
	public GameObject top_jaw;
	public GameObject foot1;
	public GameObject foot2;
	public GameObject foot3;
	public GameObject foot4;
	public GameObject neck_piece;
	public GameObject tail_1;
	public GameObject tail;
	
	public bool jumping = false;
	public RewardSprite rewardSprite;
	
	public tk2dSprite body_sprite;
	private tk2dSprite bottom_jaw_sprite;
	private tk2dSprite top_jaw_sprite;
	private tk2dSprite foot1_sprite;
	private tk2dSprite foot2_sprite;
	private tk2dSprite foot3_sprite;
	private tk2dSprite foot4_sprite;
	private tk2dSprite neck_piece_sprite;
	public tk2dSprite tail_1_sprite;
	public tk2dSprite tail_sprite;
	
	void Awake() {
//		body = transform.Find ("Body").gameObject;
//		bottom_jaw = transform.Find("Bottom Jaw").gameObject;
//		top_jaw = transform.Find ("Top Jaw").gameObject;
		
//		foot1 = transform.Find ("Foot 1").gameObject;
//		foot2 = transform.Find ("Foot 2").gameObject;
//		foot3 = transform.Find ("Foot 3").gameObject;
//		foot4 = transform.Find ("Foot 4").gameObject;
		
//		neck_piece = transform.Find("Neck Piece").gameObject;
//		tail_1 = transform.Find("Tail 1").gameObject;
//		tail = transform.FindChild ("Tail").gameObject;
	}
	
	
	// Use this for initialization
	void Start () {

		
		body_sprite = body.GetComponent<tk2dSprite>();
		bottom_jaw_sprite = bottom_jaw.GetComponent<tk2dSprite>();
		top_jaw_sprite = top_jaw.GetComponent<tk2dSprite>();
		foot1_sprite = foot1.GetComponent<tk2dSprite>();
		foot2_sprite = foot2.GetComponent<tk2dSprite>();
		foot3_sprite = foot3.GetComponent<tk2dSprite>();
		foot4_sprite = foot4.GetComponent<tk2dSprite>();
		neck_piece_sprite = neck_piece.GetComponent<tk2dSprite>();
		tail_1_sprite = tail_1.GetComponent<tk2dSprite>();
		tail_sprite = tail.GetComponent<tk2dSprite>();
		
		
		
		
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
	
	void LateUpdate() {
		switch(alligatorColor) {		
			case AlligatorColors.green:
				body_sprite.SetSprite("green_body");
				bottom_jaw_sprite.SetSprite("green_bottom jaw");
				top_jaw_sprite.SetSprite("green_top jaw");
				foot1_sprite.SetSprite("green_foot 1");
				foot2_sprite.SetSprite("green_foot 2");
				foot3_sprite.SetSprite("green_foot 3");
				foot4_sprite.SetSprite("green_foot 4");
				neck_piece_sprite.SetSprite("green_neck piece");
				tail_1_sprite.SetSprite("green_tail 1");
				tail_sprite.SetSprite("green_tail 2");
				break;
			case AlligatorColors.blue:
				body_sprite.SetSprite("blue_body");
				bottom_jaw_sprite.SetSprite("blue_bottom jaw");
				top_jaw_sprite.SetSprite("blue_top jaw");
				foot1_sprite.SetSprite("blue_foot 1");
				foot2_sprite.SetSprite("blue_foot 2");
				foot3_sprite.SetSprite("blue_foot 3");
				foot4_sprite.SetSprite("blue_foot 4");
				neck_piece_sprite.SetSprite("blue_neck piece");
				tail_1_sprite.SetSprite("blue_tail 1");
				tail_sprite.SetSprite("blue_tail 2");
				break;
			case AlligatorColors.pink:
				body_sprite.SetSprite("pink_body");
				bottom_jaw_sprite.SetSprite("pink_bottom jaw");
				top_jaw_sprite.SetSprite("pink_top jaw");
				foot1_sprite.SetSprite("pink_foot 1");
				foot2_sprite.SetSprite("pink_foot 2");
				foot3_sprite.SetSprite("pink_foot 3");
				foot4_sprite.SetSprite("pink_foot 4");
				neck_piece_sprite.SetSprite("pink_neck piece");
				tail_1_sprite.SetSprite("pink_tail 1");
				tail_sprite.SetSprite("pink_tail 2");
				break;
			case AlligatorColors.red:
				body_sprite.SetSprite("redbody");
				bottom_jaw_sprite.SetSprite("redbottom jaw");
				top_jaw_sprite.SetSprite("redtop jaw");
				foot1_sprite.SetSprite("redfoot 1");
				foot2_sprite.SetSprite("redfoot 2");
				foot3_sprite.SetSprite("redfoot 3");
				foot4_sprite.SetSprite("redfoot 4");
				neck_piece_sprite.SetSprite("redneck piece");
				tail_1_sprite.SetSprite("redtail 1");
				tail_sprite.SetSprite("redtail 2");
				break;
			case AlligatorColors.yellow:

				body_sprite.SetSprite("yellow_body");
				bottom_jaw_sprite.SetSprite("yellow_bottom jaw");
				top_jaw_sprite.SetSprite("yellow_top jaw");
				foot1_sprite.SetSprite("yellow_foot 1");
				foot2_sprite.SetSprite("yellow_foot 2");
				foot3_sprite.SetSprite("yellow_foot 3");
				foot4_sprite.SetSprite("yellow_foot 4");
				neck_piece_sprite.SetSprite("yellow_neck piece");
				tail_1_sprite.SetSprite("yellow_tail 1");
				tail_sprite.SetSprite("yellow_tail 2");
				break;			
		}
		
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
