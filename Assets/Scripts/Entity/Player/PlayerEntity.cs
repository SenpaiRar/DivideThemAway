using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public int StartingHP;
    public int currentHP;
    public float HitfreezeTime;
    public AudioClip DamageSound;
    public AudioClip DeathSound;
    public AudioSource AudioSrc;

    private void Start()
    {
        currentHP = StartingHP;
    }
    public override void TakeDamage(int T)
    {
        currentHP -= T;
        AudioSrc.PlayOneShot(DamageSound);
        StartCoroutine(HitFreeze());
        if(currentHP <= 0)
        {
            AudioSrc.PlayOneShot(DeathSound, 0.6f);
        }

    }
    IEnumerator HitFreeze (){
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(HitfreezeTime);
        Time.timeScale = 1;
    }


}
