using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BossMusic : MonoBehaviour
{
    public AudioMixerSnapshot FinalDanceOn;
    public AudioMixerSnapshot HeavyBullshitOn;
    public AudioMixerSnapshot UpbeatSlamOn;
    public AudioMixerSnapshot NoMusic;

    [SerializeField] private HealthState healthState;
    public enum HealthState
    {
        FullHealth,
        MediumHealth,
        LowHealth
    }
    private void Start()
    {
        healthState = HealthState.FullHealth;
    }
    public void updateSound(int currentHealth)
    {

        if (currentHealth < 330000 && healthState != HealthState.LowHealth) {
            healthState = HealthState.LowHealth;
            HeavyBullshitOn.TransitionTo(4);
        } else if (currentHealth < 660000 && healthState != HealthState.MediumHealth) {
            healthState = HealthState.MediumHealth;
            UpbeatSlamOn.TransitionTo(4);
        }

    }
}
