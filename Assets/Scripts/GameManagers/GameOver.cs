using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public PlayerEntity Source;
    public GameObject GameOverCanvas;
    public Animator SweepAnimation;
    public Animator WeaponTextAnimation;
    public Animator HealthTextAnimation;
    private void Start()
    {
        GameOverCanvas.SetActive(false);
        PlayerEntity.OnPlayerDeath += StartAnimations;
        PlayerEntity.OnPlayerDeath += ZA_WARUDO;
        PlayerEntity.OnPlayerHit += StartDamageAnims;
    }

    void StartAnimations()
    {
        GameOverCanvas.SetActive(true);
        SweepAnimation.SetBool("GameOver", true);
        WeaponTextAnimation.SetBool("GameOver", true);
        HealthTextAnimation.SetBool("GameOver", true);
    }
    void ZA_WARUDO()
    {
        StartCoroutine(SlowdownTime());
    }
    void StartDamageAnims()
    {
        HealthTextAnimation.SetTrigger("TakenDamage");
    }
    IEnumerator SlowdownTime()
    {
        while (Time.timeScale > 0)
        {
            float x = 10; //Constant
            Time.timeScale -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
