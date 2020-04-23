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
    }
    
    void StartAnimations(){
        GameOverCanvas.SetActive(true);
        SweepAnimation.SetBool("GameOver", true);
        WeaponTextAnimation.SetBool("GameOver", true);
        HealthTextAnimation.SetBool("GameOver", true);
    }
    void ZA_WARUDO(){
        Time.timeScale = 0;
    }
}
