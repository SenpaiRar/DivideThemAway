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
    public override int GetDamage()
    {
        return (DamageValue);
    }
}
