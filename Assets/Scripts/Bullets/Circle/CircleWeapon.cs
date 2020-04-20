using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWeapon : Bullet
{
    public int DamageValue;
    public int Speed;
    public float Lifetime;

    private void Start(){
        StartCoroutine(Lifespan());
    }
    void FixedUpdate(){
        transform.Translate(Vector3.forward*Speed*Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag != "Player"){
            col.GetComponent<Entity>().TakeDamage(DamageValue);
        }
    }
    public override int GetDamage(){
        return DamageValue;
    }
    IEnumerator Lifespan(){
        yield return new WaitForSecondsRealtime(Lifetime);
        Destroy(gameObject);
    }
    
}
