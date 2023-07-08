using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;






public class PlaySFX : MonoBehaviour
{

    [SerializeField] private AudioSource goblinAtk;
    public AudioMixerSnapshot FinalDanceOn;
    public AudioMixerSnapshot HeavyBullshitOn;
    public AudioMixerSnapshot UpbeatSlamOn;
    public AudioMixerSnapshot NoMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.W))
        {
            goblinAtk.Play();
        } else if (Input.GetKeyDown(KeyCode.A))
        {
           FinalDanceOn.TransitionTo(4);
        } else if (Input.GetKeyDown(KeyCode.D)){
            HeavyBullshitOn.TransitionTo(4);
        } else if (Input.GetKeyDown(KeyCode.S)){
            UpbeatSlamOn.TransitionTo(4);
        } else if (Input.GetKeyDown(KeyCode.F)){
            NoMusic.TransitionTo(4);
        }
        
    }
}
