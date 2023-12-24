using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource DeathSound;
    public AudioSource FootstepSound;
    public AudioSource JumpSound;
    public AudioSource DoubleJumpSound;
    public AudioSource DamageSound;
    
    public void playDeathSound() {
        DeathSound.Play();
    }
    public void stopDeathSound() {
        DeathSound.Stop();
    }
    public void playFootstepSound() {
        FootstepSound.Play();
        FootstepSound.loop = true;
    }
    public void stopFootstepSound() {
        FootstepSound.Stop();
    }
    public void playJumpSound() {
        JumpSound.Play();
    }

    public void stopJumpSound() {
        JumpSound.Stop();
    }
    public void playDoubleJumpSound() {
        DoubleJumpSound.Play();
    }

    public void stopDoubleJumpSound() {
        DoubleJumpSound.Stop();
    }
    public void playDamageSound() {
        DamageSound.Play();
    }

    public void stopDamageSound() {
        DamageSound.Stop();
    }
}
