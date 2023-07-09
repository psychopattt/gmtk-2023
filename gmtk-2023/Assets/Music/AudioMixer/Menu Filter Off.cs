using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuFilterOff : MonoBehaviour
{
    public AudioMixerSnapshot FinalDanceOn;
    // Start is called before the first frame update
    void Start()
    {
        FinalDanceOn.TransitionTo(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
