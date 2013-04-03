using UnityEngine;
using System.Collections;

public class Phoneme : MonoBehaviour {
	public static string[] VOICES = new string[] {"filip_dirty_test"}; // TODO: this could probably go elsewhere 
	public string letter;
	public string voice;
	public AudioSource audioSource;
	public AudioClip audioClip;
	public AudioClip rewardClip;

	// Use this for initialization
	void Awake () {
		voice = VOICES[0];
		audioSource = Camera.mainCamera.GetComponent<AudioSource>();
		rewardClip = Resources.Load("_sfx/jump") as AudioClip;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	string filename() {
		return letter;
	}
	
	public void setLetter(string l) {
		letter = l;
		audioClip = Resources.Load(voice + "/" + filename()) as AudioClip;
	}
	public void PlayClip() {
		DoPlayClip (0);
	}

	public void PlayClip(float delay) {
		DoPlayClip (delay);
	}

	private void DoPlayClip(float delay) {
		//yield return new WaitForSeconds(delay);
		audioSource.PlayOneShot(audioClip);

	}

		
	
	public void PlayRewardClip() {
		audioSource.PlayOneShot(rewardClip);
	}

}
