using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    public abstract override void TakeDamage(int T);
    public abstract void SpawnRoutine(Vector3 T);
    
}
