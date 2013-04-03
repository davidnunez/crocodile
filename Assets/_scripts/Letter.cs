using UnityEngine;
using System.Collections;

/*
 * class letter {
--every letter we display is it’s own letter object associated with a specific filename and specific attributes. Thus, we will easily be able to track what the kids tapped. 
--fields
filename: string. unique ID as well as the reference path. all letters are stored as white fill on transparent background in  png (masters in ai illustrator files).
letter: string. what letter it is (a-z).
font: string. what font it belongs to. (Helvetica high bold)
typeface: string. what typeface it is. (Helvetica) maybe inherited from font.
uppercase: boolean. maybe inherited from font.
italic: boolean. maybe inherited from font.
bold:boolean. maybe inherited from font.
serif:boolean. maybe inherited from font.
letterSets: array. info to which letterSets the letter belongs to. 
}
 */

public class Letter : MonoBehaviour {
	public static string[] TYPEFACES = new string[] {"courierNew", "museo", "philosopher"}; // TODO: this could probably go elsewhere 
	public string letter;
	public string typeface;
	public bool uppercase;
	
	// TODO: decide if these are needed:
	// public string font; // maybe we don't need this?
	//public bool italic;
	//public bool bold;
	//public bool serif;
	float lerpPosition = 0.0f;
	public float lerpTime  = 10.0f; // This is the number of seconds the Lerp will take
	Vector3 start;
	Vector3 end; 

	
	// LetterSet[] letterSets; // TODO: Implement Letter Set
	
	// Use this for initialization
	void Start () {
		start = transform.position;
		end = new Vector3(start.x, -100, start.z);
	}
	
	// Update is called once per frame
	void Update () {
	    lerpPosition += Time.deltaTime/lerpTime;
    	transform.position = Vector3.Lerp(start,end,lerpPosition);
	
	}	
	
	public void Randomize() {// will need to make this function more robust / customizable
		letter = AlphabetMap.getLetter(Random.Range(1,27));
		typeface = TYPEFACES[Random.Range(0, TYPEFACES.Length)];
		
		
		uppercase = Random.Range(0,2) == 1;

	}

	
	
	public string filename() {
		string highlow;
		if (uppercase) {
			highlow = "High";
		} else {
			highlow = "Low";
		}
		return typeface + highlow + "-" + AlphabetMap.getIndex(letter).ToString("D2");
;
	}
}