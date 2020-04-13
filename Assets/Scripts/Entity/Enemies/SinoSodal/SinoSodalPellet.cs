using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinoSodalPellet : Entity
{
    public float Frequency;
    public float Offset;
    public float Amp;

    private void Start(){
        Offset = Time.time;
    }
    private void Update(){
       transform.localPosition = new Vector3(Amp*Mathf.Sin((Time.time-Offset)*Frequency),0,0);
   }
    void OnTriggerEnter(Collider col){
       if(col.gameObject.tag == "Player"){
           col.gameObject.GetComponent<Entity>().TakeDamage(1);
           Destroy(transform.parent.gameObject);
       }
   }
   public override void TakeDamage(int T){
       Destroy(gameObject);
   }
   
}
