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

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> EnemyTypesAvailable = new List<Enemy>();
    public List<Collider> SpawnRegions = new List<Collider>();
    public Difficulty CurrentDifficulty;
    public float TimeBetweenWaves;
    public bool ShouldSpawnEnemies;
    public int MaxEnemyCount;
    
    private void Start()
    {
        ShouldSpawnEnemies = true;
        StartCoroutine(RampUpDifficulty());
        StartCoroutine(SpawnEnemies());
        StartCoroutine(CheckEnemyLevels());
    }
    private void Update(){
        Debug.Log(CurrentDifficulty);
    }

    IEnumerator SpawnEnemies()
    {
        
        for(; ; )
        {
            while(ShouldSpawnEnemies){
            foreach (Enemy item in EnemyTypesAvailable)
            {
                for (int i = 0; i < (int)CurrentDifficulty; i++)
                {
                    int x = Random.Range(0,4);
                    item.SpawnRoutine(new Vector3(Random.Range(SpawnRegions[x].bounds.min.x,SpawnRegions[x].bounds.max.x),0,Random.Range(SpawnRegions[x].bounds.min.z,SpawnRegions[x].bounds.max.z)));
                }
                
            }
            yield return new WaitForSecondsRealtime(TimeBetweenWaves);
            }
            yield return new WaitForSecondsRealtime(1.0f);
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
