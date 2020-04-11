using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public int StartingHP;

    public int currentHP;

    private void Start()
    {
        currentHP = StartingHP;
    }
    public override void TakeDamage(int T)
    {
        currentHP -= T;
        if(currentHP <= 0)
        {
            //TODO: Player Death
        }

    }
    
}
