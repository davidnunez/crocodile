using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	
	public int numberOfLetters = 4;
	public Letter[] letters;
	public Phoneme phoneme;
	// Use this for initialization
	void Awake () {
		letters = new Letter[numberOfLetters];

		GameObject phonemeObject = (GameObject)Instantiate (Resources.Load ("_prefabs/PhonemePrefab"));
		phoneme = phonemeObject.GetComponent<Phoneme>();
	}
	void OnEnable() {
    //    FingerGestures.OnFingerDown += FingerGestures_OnFingerDown;
	}
	void OnDisable() {
    //    FingerGestures.OnFingerDown -= FingerGestures_OnFingerDown;
	}	
	void Start() {
		setupLetters();
		setupPhoneme();
		phoneme.PlayClip();
	}
	
	void FingerGestures_OnFingerDown( int fingerIndex, Vector2 fingerPos ) {
		GameObject selectedObject = PickGameObject(fingerPos);
		if (selectedObject) {
			Letter letter = selectedObject.GetComponent<Letter>();
			if (letter.letter == phoneme.letter) {
				phoneme.PlayRewardClip();
				clearLetters();
				setupLetters();
				setupPhoneme();
				phoneme.PlayClip(0.5f);

			} else {
				phoneme.PlayClip();
				Destroy(selectedObject);
			}
		} else {
			phoneme.PlayClip();
		}
		
		
	}

	void setupLetters() {
		for (int i = 0; i < numberOfLetters; i++) {		
			Vector3 newPosition = new Vector3(200+200*i, 900, 0);
			
			GameObject go = (GameObject)Instantiate (Resources.Load ("_prefabs/LetterPrefab"), newPosition,Quaternion.identity);	
			Letter letter = go.GetComponent<Letter>();
			letter.Randomize();
			string textureName = "font_sets/" + letter.typeface + "/" + letter.filename();
			
			Texture2D tex = Resources.Load(textureName) as Texture2D;

			go.renderer.material.mainTexture = tex;
			
			Debug.Log (textureName);
			letters[i] = letter;
		}
	}
		
	void clearLetters() {
		for (int i = 0; i < numberOfLetters; i++) {	
			if (letters[i]) {
			Destroy(letters[i].gameObject);
			}
		}
			
		
		
	}
	void setupPhoneme(){
		phoneme.setLetter(letters[Random.Range(0, letters.Length)].letter);
		phoneme.PlayClip();

	}
	
	// Update is called once per frame
	void Update () {
		
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
	
}
