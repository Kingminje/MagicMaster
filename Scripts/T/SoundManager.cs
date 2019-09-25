using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource _audioSources;

    public AudioClip _audioclips; 

	// Use this for initialization
	void Start () {

        _audioSources.clip = _audioclips;
        _audioSources.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
