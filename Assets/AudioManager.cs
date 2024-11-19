using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header ("-----Audio Sound-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header ("-----Clip Sound-----")]
    public AudioClip background;
    public AudioClip checkpoint;
    public AudioClip wallTouch;
    public AudioClip miss;
    
    private void Start() 
    {
        musicSource.clip = background;
        musicSource.Play();
    }
     public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
