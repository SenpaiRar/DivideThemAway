using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pea :Bullet
{
    public int DamageValue;
    public float Speed;
    public float TimeToDestroy;
    float timer;

    private void Start(){
        StartCoroutine(Lifespan());
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime, Space.Self);
    }
    
    void OnTriggerEnter(Collider Col){
        if(Col.tag == "Enemy" || Col.tag=="Enemy_Bullet"){
            Entity x = Col.gameObject.GetComponent<Entity>();
            x.TakeDamage(DamageValue);
            Destroy(gameObject);
        }
        Debug.Log("Encounted Collision");
    }

    public override int GetDamage()
    {
        return (DamageValue);
    }

   IEnumerator Lifespan(){
       yield return new WaitForSecondsRealtime(10.0f);
       Destroy(gameObject);
   }
}
