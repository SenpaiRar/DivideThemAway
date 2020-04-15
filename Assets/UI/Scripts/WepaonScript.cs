using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WepaonScript : MonoBehaviour
{

    public Text WeaponText;
    public PlayerShoot Source;

    private void Update(){
        WeaponText.text = "Equation:"+Source.CurrentWeaponObject.Name;
    }
    
}
