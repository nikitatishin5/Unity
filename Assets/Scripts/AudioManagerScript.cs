using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {

    public AudioSource AudioSource;

    public AudioClip AudioClip;

    public int volume;
	// Use this for initialization
	void Start () {
        AudioSource.clip = AudioClip;
        AudioSource.loop = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("AudioSource.Play()");
            AudioSource.PlayOneShot(AudioClip, volume);
        }
	}
}
