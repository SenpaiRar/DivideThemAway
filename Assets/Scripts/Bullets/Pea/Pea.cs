using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pea :Bullet
{
    public int DamageValue;
    public float Speed;
    public float TimeToDestroy;
    float timer;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime, Space.Self);
        timer += Time.deltaTime;
        if(timer > TimeToDestroy)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider Col){
        if(Col.gameObject.tag == "Enemy"){
            Entity x = Col.gameObject.GetComponent<Entity>();
            x.TakeDamage(1);
            Destroy(gameObject);
        }
        Debug.Log("Encounted Collision");
    }

    public override int GetDamage()
    {
        return (DamageValue);
    }

   
}
