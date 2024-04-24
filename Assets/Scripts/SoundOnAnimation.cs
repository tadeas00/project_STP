using UnityEngine;

public class SoundOnAnimation : MonoBehaviour
{
    public AudioSource audioSource; 

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound()
    {
        audioSource.Play();
    }
}