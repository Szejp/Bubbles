using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public AudioClip _clip;

    private AudioSource aSource;

    public void Play(AudioClip clip)
    {       
        if(aSource != null)
        {
            if (aSource.clip == clip)
            {
                aSource.Play();
            }
            else
            {
                aSource.clip = clip;
                aSource.Play();
            }        
        }
    }

	// Use this for initialization
	void Start () {

        aSource = gameObject.GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
