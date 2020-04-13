using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinoSodalPellet : MonoBehaviour
{
    public float Frequency;
   private void Update(){
       transform.localPosition = new Vector3(Mathf.Sin(Time.time*Frequency),0,0);
   }
}
