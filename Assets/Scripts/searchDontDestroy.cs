using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class searchDontDestroy : MonoBehaviour
{
    GameObject managDontDestr;
    [SerializeField] Toggle toggleMusic;
    void Start()
    {
        managDontDestr = GameObject.Find("ManageDontDestroy");
        toggleMusic.GetComponent<Toggle>().isOn = managDontDestr.GetComponent<ManageScenes>().audioOn;
    }

    // Update is called once per frame
    public void SoundEnabling(Toggle thisOne)
    {
        if (thisOne.isOn)
        {
            managDontDestr.GetComponent<AudioSource>().Play();
            managDontDestr.GetComponent<ManageScenes>().audioOn = true;
        }
        else
        {
            managDontDestr.GetComponent<AudioSource>().Stop();
            managDontDestr.GetComponent<ManageScenes>().audioOn = false;
        }
        
    }
}
