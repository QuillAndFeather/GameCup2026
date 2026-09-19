using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    /// <summary>
    /// To Utilize this Prefab
    /// Put it as a child to the gameobject that needs to play audio
    /// Add AudioPlayer as a variable within the script that will play sounds [I.E. Door Interation, the highest parent in the hierarchy]
    /// And to assign it, it can be done via the prefab or using GetComponentInChildren<AudioPlayer>()
    /// Either way works
    /// Then when a sound needs to be played
    /// In the parent, call the variable and one of the two functions below to what is needed.
    /// This is to avoid clips being cut off from another playing
    /// </summary>

    [SerializeField] AudioClip[] audioClips; //Array of audio clips that can be played
    private AudioSource audioPlayer; //Audio player component to play sounds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>(); //Grab the component
    }

    // Audio playing functions

    //Will play a random sound from the array
    public void PlayRandomSound()
    {
        int soundIndex = Random.Range(0, audioClips.Length); //Grab a random sound index

        audioPlayer.PlayOneShot(audioClips[soundIndex]); //Play the specified audio clip
    }

    //Will play the specified index sound
    public void PlaySpecifiedSound(int soundIndex)
    {
        //Ensure the index isn't out of bounds, return if so
        if (soundIndex < 0 || soundIndex >= audioClips.Length)
        {
            Debug.Log("Index out of bounds");

            return;
        }

        audioPlayer.PlayOneShot(audioClips[soundIndex]); //Player the specified audio clip
    }
}
