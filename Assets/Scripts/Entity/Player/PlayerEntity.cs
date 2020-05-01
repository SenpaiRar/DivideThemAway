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

    public delegate void PlayerStatus();
    public static event PlayerStatus OnPlayerDeath;
    public static event PlayerStatus OnPlayerHit;
    private void Start()
    {
        currentHP = StartingHP;
    }
    public override void TakeDamage(int T)
    {
        currentHP -= T;
        if(currentHP>0){
            if (OnPlayerHit != null)
                OnPlayerHit.Invoke();
            AudioSrc.PlayOneShot(DamageSound, AudioConstant.AudioScale);
            StartCoroutine(HitFreeze());
        }
        else
        {
            AudioSrc.PlayOneShot(DeathSound, AudioConstant.AudioScale);
            if(OnPlayerDeath !=null)
                OnPlayerDeath.Invoke();
        }

    }
    IEnumerator HitFreeze (){
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(HitfreezeTime);
        Time.timeScale = 1;
    }


}
