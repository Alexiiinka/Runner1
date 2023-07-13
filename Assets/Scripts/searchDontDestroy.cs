using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class searchDontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject managDontDestr;
    void Start()
    {
        managDontDestr = GameObject.Find("ManageDontDestroy");
    }

    // Update is called once per frame
    public void SoundEnabling(Toggle thisOne)
    {
        if (thisOne.isOn)
        {
            managDontDestr.GetComponent<AudioSource>().Play();
        }
        else
        {
            managDontDestr.GetComponent<AudioSource>().Stop();
        }
        
    }
}
