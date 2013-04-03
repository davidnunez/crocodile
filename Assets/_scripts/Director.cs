using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	

	int[] validLetters = {2,4,6,12,13,14,16,19,20};

	public int numberOfLetters = 4;
	public Letter[] letters;
	public Phoneme phoneme;
	public alligator alligator;
	// Use this for initialization
	void Awake () {
		letters = new Letter[numberOfLetters];

		GameObject phonemeObject = (GameObject)Instantiate (Resources.Load ("_prefabs/PhonemePrefab"));
		phoneme = phonemeObject.GetComponent<Phoneme>();
	}
	void OnEnable() {
        FingerGestures.OnFingerDown += FingerGestures_OnFingerDown;
	}
	void OnDisable() {
        FingerGestures.OnFingerDown -= FingerGestures_OnFingerDown;
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
				alligator.JumpToPoint(letter.gameObject.transform.position.x-50, letter.gameObject.transform.position.y-30);				
				StartCoroutine("ClearCorrectLetter", letter);
				
				

			} else {
				phoneme.PlayClip();
				letter.Fall();
				//Destroy(selectedObject);
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
			letter.Randomize(validLetters);
			string textureName = "font_sets/" + letter.typeface + "/" + letter.filename();
			
			Texture2D tex = Resources.Load(textureName) as Texture2D;

			go.renderer.material.mainTexture = tex;
			
			letters[i] = letter;
		}
	}
	
	IEnumerator ClearCorrectLetter(Letter letter) {
		clearLetters();

		iTween.ScaleTo(letter.gameObject, iTween.Hash("x", 0, "y", 0, "delay", 0.75f, "time", 0.5f));
		yield return new WaitForSeconds(1.5f);
		Destroy(letter.gameObject);
		yield return new WaitForSeconds(2.5f);
		setupLetters();
		setupPhoneme();
		phoneme.PlayClip(0.5f);
	}
		
	void clearLetters() {
		for (int i = 0; i < numberOfLetters; i++) {	
			if (letters[i] && letters[i].letter != phoneme.letter) {
				letters[i].Fall();
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
