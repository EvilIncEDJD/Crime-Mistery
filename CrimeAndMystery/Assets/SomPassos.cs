using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPassos : MonoBehaviour {

	[SerializeField]
	private AudioClip[] audioclips_;
	private AudioSource audioSource;


	private void Awake(){
		audioSource = GetComponent<AudioSource>();
	}

	private void Step(){
		AudioClip clip = GetRandomClip();
		audioSource.PlayOneShot(clip);
	}
	
	private AudioClip GetRandomClip(){
		return audioclips_[UnityEngine.Random.Range(0,audioclips_.Length)];
	}
}
