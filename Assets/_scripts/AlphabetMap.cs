using UnityEngine;
using System.Collections;

public class AlphabetMap : MonoBehaviour {
	
	public static Hashtable letterToIndex = new Hashtable();
	public static Hashtable indexToLetter = new Hashtable();

	// Use this for initialization
	void OnEnable () {
		letterToIndex.Add("a", 1);
		letterToIndex.Add("b", 2);
		letterToIndex.Add("c", 3);
		letterToIndex.Add("d", 4);
		letterToIndex.Add("e", 5);
		letterToIndex.Add("f", 6);
		letterToIndex.Add("g", 7);
		letterToIndex.Add("h", 8);
		letterToIndex.Add("i", 9);
		letterToIndex.Add("j", 10);
		letterToIndex.Add("k", 11);
		letterToIndex.Add("l", 12);
		letterToIndex.Add("m", 13);
		letterToIndex.Add("n", 14);
		letterToIndex.Add("o", 15);
		letterToIndex.Add("p", 16);
		letterToIndex.Add("q", 17);
		letterToIndex.Add("r", 18);
		letterToIndex.Add("s", 19);
		letterToIndex.Add("t", 20);
		letterToIndex.Add("u", 21);
		letterToIndex.Add("v", 22);
		letterToIndex.Add("w", 23);
		letterToIndex.Add("x", 24);
		letterToIndex.Add("y", 25);
		letterToIndex.Add("z", 26);
		
		indexToLetter.Add (1, "a");
		indexToLetter.Add (2, "b");
		indexToLetter.Add (3, "c");
		indexToLetter.Add (4, "d");
		indexToLetter.Add (5, "e");
		indexToLetter.Add (6, "f");
		indexToLetter.Add (7, "g");
		indexToLetter.Add (8, "h");
		indexToLetter.Add (9, "i");
		indexToLetter.Add (10, "j");
		indexToLetter.Add (11, "k");
		indexToLetter.Add (12, "l");
		indexToLetter.Add (13, "m");
		indexToLetter.Add (14, "n");
		indexToLetter.Add (15, "o");
		indexToLetter.Add (16, "p");
		indexToLetter.Add (17, "q");
		indexToLetter.Add (18, "r");
		indexToLetter.Add (19, "s");
		indexToLetter.Add (20, "t");
		indexToLetter.Add (21, "u");
		indexToLetter.Add (22, "v");
		indexToLetter.Add (23, "w");
		indexToLetter.Add (24, "x");
		indexToLetter.Add (25, "y");
		indexToLetter.Add (26, "z");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	static public string getLetter(int index) {
		return (string)indexToLetter[index];
	}

	static public int getIndex(string letter) {
		return (int) letterToIndex[letter];
	}

	
}
