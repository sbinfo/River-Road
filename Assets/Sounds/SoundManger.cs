using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour {

    public GameObject sfx;
    public AudioClip[] audioClips;

    public void PlaySound(int soundNum)
    {

        GameObject s = Instantiate(sfx, transform.position, Quaternion.identity) as GameObject;
        AudioSource AS = s.GetComponent<AudioSource>();

        AS.clip = audioClips[soundNum];
        AS.Play();
        Destroy(s, 2); 
    }
}
