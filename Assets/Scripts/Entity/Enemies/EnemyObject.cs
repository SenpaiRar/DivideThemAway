using System.Collections;
using System;
using UnityEngine;

[CreateAssetMenu(fileName="Enemy", menuName="Enemy")]
public class EnemyObject : ScriptableObject{
    public GameObject Enemy;
    public Difficulty LevelToSpawnAt;
    public int numberMultiplier;
    public float SpawnInterval;
}