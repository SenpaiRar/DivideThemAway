using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public int StartingHP;
    public int currentHP;
    public AudioClip DamageSound;
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
            //TODO: Player Death
        }

    }
    IEnumerator HitFreeze (){
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
    }


}
