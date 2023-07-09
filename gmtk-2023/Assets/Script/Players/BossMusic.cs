using UnityEngine;
using UnityEngine.Audio;

public class BossMusic : MonoBehaviour
{
    public AudioMixerSnapshot FinalDanceOn;
    public AudioMixerSnapshot HeavyBullshitOn;
    public AudioMixerSnapshot UpbeatSlamOn;
    public AudioMixerSnapshot NoMusic;

    public void updateSound(int currentHealth)
    {
        if (currentHealth < 500000 ) {
            HeavyBullshitOn.TransitionTo(4);
        } else if (currentHealth < 750000) {
            UpbeatSlamOn.TransitionTo(4);
        }

    }
}
