using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : Entity
{
    public int Health;
    int x;
    
    void Start(){
        x = Health;
    }
    public override void TakeDamage(int T){
        x-=T;
        if(x<=0)
            Destroy(gameObject);
    }
}
