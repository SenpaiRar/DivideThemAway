using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public PlayerEntity Source;
    public GameObject GameOverCanvas;
    public Animator Anima;
    private void Start()
    {
        GameOverCanvas.SetActive(false);
    }
    private void Update(){
        if(Source.currentHP <= 0){
            GameOverCanvas.SetActive(true);
            Anima.SetBool("GameOver", true);

            Time.timeScale = 0;
            
        }
    }
}
