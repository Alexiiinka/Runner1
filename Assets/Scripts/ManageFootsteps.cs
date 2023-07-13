using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFootsteps : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    List<AudioClip> footSounds;
    [SerializeField]
    AudioClip bamSound;
    [SerializeField]
    AudioClip birdSound;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayStep()
    {
        source.PlayOneShot(footSounds[Random.Range(0,2)]);
    }
    public void PlayStep2()
    {
        source.PlayOneShot(footSounds[Random.Range(2,4)]);
    }
    public void PlayBam()
    {
        source.PlayOneShot(bamSound);
    }
    public void PlayBirds()
    {
        source.PlayOneShot(birdSound);
    }
}
