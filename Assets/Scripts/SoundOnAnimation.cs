using UnityEngine;

public class SoundOnAnimation : MonoBehaviour
{
    public AudioSource audioSource; // Reference na AudioSource

    void Start()
    {
        // Získání komponenty AudioSource, pokud není nastavena
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // Metoda, která spustí zvuk
    public void PlaySound()
    {
        audioSource.Play();
    }
}