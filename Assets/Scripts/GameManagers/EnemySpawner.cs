using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Beginning = 1,
    Medium = 2,
    Hard = 4,
    Insane = 8
}

public class SpawnObjectInternal{
    public SpawnObjectInternal(GameObject Internal, float TimeB){
        if(Internal.GetComponent<Enemy>() == null){
            throw new System.Exception();
        }
        this.InternalEnemy = Internal;
        this.TimeBetweenSpawns = TimeB;
        this.EnemyDiff = Internal.GetComponent<EnemyObject>().LevelToSpawnAt;
    }
    public GameObject InternalEnemy;
    public Difficulty EnemyDiff;
    public float TimeBetweenSpawns;
    public float TimePassedSinceSpawn;
}

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyObject> EnemyTypesAvailable = new List<EnemyObject>();
    public List<SpawnObjectInternal> Spawnables = new List<SpawnObjectInternal>();
    public List<Collider> SpawnRegions = new List<Collider>();
    public Difficulty CurrentDifficulty;
    public float TimeBetweenWaves;
    public bool ShouldSpawnEnemies;
    public int MaxEnemyCount;
    
    private void Start()
    {
        ShouldSpawnEnemies = true;
        PopulateInternalList();
        StartCoroutine(RampUpDifficulty());
        StartCoroutine(SpawnEnemies());
        StartCoroutine(CheckEnemyLevels());
    }
    private void Update(){
        Debug.Log(CurrentDifficulty);
    }
    void PopulateInternalList(){
        foreach(EnemyObject x in EnemyTypesAvailable){
            Spawnables.Add(new SpawnObjectInternal(x.Enemy, x.SpawnInterval));
        }
    }
    Vector3 GetRandPosInRegion(){
        int x = Random.Range(0,SpawnRegions.Count-1);
        Vector3 RandPos = new Vector3(Random.Range(SpawnRegions[x].bounds.min.x,SpawnRegions[x].bounds.max.x),0,Random.Range(SpawnRegions[x].bounds.min.z,SpawnRegions[x].bounds.max.z));
        return RandPos;
    }

    IEnumerator SpawnEnemies()
    {
        
        for(; ; )
        {
            foreach (SpawnObjectInternal x in Spawnables){
                if(x.EnemyDiff >= CurrentDifficulty){
                    
                    if(x.TimePassedSinceSpawn > x.TimeBetweenSpawns){
                        x.InternalEnemy.GetComponent<Enemy>().SpawnRoutine(GetRandPosInRegion());
                        x.TimePassedSinceSpawn = 0;
                        x.TimePassedSinceSpawn+=Time.deltaTime;
                    }
                    else{
                        x.TimePassedSinceSpawn+=Time.deltaTime;
                    }
                }
            }
            
            yield return new WaitForEndOfFrame();
        }
        
    }
    IEnumerator RampUpDifficulty()
    {
        CurrentDifficulty = Difficulty.Beginning;
        yield return new WaitForSecondsRealtime(30f);
        
        for (; ; )
        {
            switch (CurrentDifficulty)
            {
                case Difficulty.Beginning:
                    CurrentDifficulty = Difficulty.Medium;
                    Debug.Log("New Level!");
                    yield return new WaitForSecondsRealtime(30*(int)CurrentDifficulty);
                    break;
                case Difficulty.Medium:
                    CurrentDifficulty = Difficulty.Hard;
                    yield return new WaitForSecondsRealtime(30*(int)CurrentDifficulty);
                    break;
                case Difficulty.Hard:
                    CurrentDifficulty = Difficulty.Insane;
                    yield return new WaitForSecondsRealtime(30*(int)CurrentDifficulty);
                    break;
                case Difficulty.Insane:
                    Debug.Log("Max Difficulty Reached!");
                    break;

            }
            yield return new WaitForEndOfFrame();
        
        }
    }
    
    IEnumerator CheckEnemyLevels(){
        for(;;){
            if(GameObject.FindGameObjectsWithTag("Enemy").Length > MaxEnemyCount-1){
                ShouldSpawnEnemies = false;
            }
            else{
                ShouldSpawnEnemies = true;
            }
            yield return new WaitForSecondsRealtime(5.0f);
        }
    }
}
