using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    public Text HealthText;
    public PlayerEntity Source;

    private void LateUpdate()
    {
        HealthText.text = Source.currentHP.ToString()+"y";

    }
}
