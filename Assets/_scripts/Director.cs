using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	

	public int[] validLetters = {2,4,6,12,13,14,16,19,20};

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
		StartCoroutine("SpeakPhoneme");
	}
	
	void FingerGestures_OnFingerDown( int fingerIndex, Vector2 fingerPos ) {
		GameObject selectedObject = PickGameObject(fingerPos);
		if (selectedObject && !alligator.jumping) {
			Letter letter = selectedObject.GetComponent<Letter>();
			if (letter.letter == phoneme.letter) {
				letter.stopped = true;
				StopCoroutine("SpeakPhoneme");
				phoneme.PlayRewardClip(0.75f);
				//alligator.JumpToPoint(letter.gameObject.transform.position.x-50, letter.gameObject.transform.position.y-(30.0f / letter.speedFactor));
				alligator.JumpToPoint(letter.gameObject.transform.position.x-50, letter.gameObject.transform.position.y+30, true);				

				StartCoroutine("ClearCorrectLetter", letter);
				
				

			} else {
				letter.Fall();
				for (int i = 0; i < numberOfLetters; i++) {		
					if (letters[i] && letters[i].letter != letter.letter) {
						letters[i].speedFactor -= 0.3f;
					}
				}
				//Destroy(selectedObject);
			}
		} else {
		}
		
		
	}

	void setupLetters() {
		Shuffle(validLetters);
		
		for (int i = 0; i < numberOfLetters; i++) {		
			Vector3 newPosition = new Vector3(200+200*i, 900, 0);
			
			GameObject go = (GameObject)Instantiate (Resources.Load ("_prefabs/LetterPrefab"), newPosition,Quaternion.identity);	
			Letter letter = go.GetComponent<Letter>();			
			letter.SetLetter(validLetters[i]);			
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
		NextRound ();

	}

	void NextRound() {
		for (int i = 0; i < numberOfLetters; i++) {	
			if (letters[i]) {
				letters[i].Fall();
			}
		}
		
		setupLetters();
		setupPhoneme();
		StartCoroutine("SpeakPhoneme");	
		
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

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < numberOfLetters; i++) {	
			if (letters[i] && letters[i].letter == phoneme.letter) {
				if (letters[i].lerpPosition > 1.0f) {
					Debug.Log ("FAILED");	
					StopCoroutine("SpeakPhoneme");
					alligator.Dunk();
					phoneme.PlayFailClip();

					NextRound();
				}
			}
		}
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
	
	IEnumerator SpeakPhoneme() {
		while (true) {
			alligator.AnimateMouthOpenClose();
			phoneme.PlayClip();
			yield return new WaitForSeconds(2.0f);
		}
		
	}
	
	
	
	public static void Shuffle<T>(T[] array)
    {
        System.Random random = new System.Random();
 
        for (int i = 0; i < array.Length; i++)
        {
            int idx = random.Next(i, array.Length);
 
            //swap elements
            T tmp = array[i];
            array[i] = array[idx];
            array[idx] = tmp;
        }  
    }

}
