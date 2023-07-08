using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class TriggerFade : MonoBehaviour {
    public AudioMixerSnapshot FadeOut;
    void Start () {
        FadeOut.TransitionTo(4);
    }
}