using UnityEngine;
using System.Collections;

public class Phoneme : MonoBehaviour {
	public static string[] VOICES = new string[] {"filip_dirty_test", "phoneme sets (1)"}; // TODO: this could probably go elsewhere 
	public string letter;
	public string voice;
	public AudioSource audioSource;
	public AudioClip audioClip;
	public AudioClip rewardClip;
	public AudioClip failClip;


	// Use this for initialization
	void Awake () {
		voice = VOICES[1];
		audioSource = Camera.mainCamera.GetComponent<AudioSource>();
		rewardClip = Resources.Load("_sfx/gulp") as AudioClip;
				failClip = Resources.Load("_sfx/splash") as AudioClip;

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

		
	public void PlayFailClip() {
		audioSource.Stop();
		audioSource.PlayOneShot(failClip);
	}
	
	public void PlayRewardClip(float delay) {
		StartCoroutine("DoPlayRewardClip", delay);
	}

	IEnumerator DoPlayRewardClip(float delay) {
		yield return new WaitForSeconds(delay);
		audioSource.PlayOneShot(rewardClip);
	
	}
	
}
