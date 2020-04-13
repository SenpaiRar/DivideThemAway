using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinoSodalEnemy : Enemy
{
    
    public Vector3 Target;
    public Vector3 Direction;
    public GameObject SinosodalBulletObject;
    private void Start(){
        Target = GameObject.FindGameObjectWithTag("Player").transform.position;
        Direction = Target-transform.position;
        StartCoroutine(SpawnSines());
    }
    public override void SpawnRoutine(Vector3 T){
        Instantiate(this.gameObject, new Vector3(T.x, 0, T.z), Quaternion.identity);
    }
    IEnumerator SpawnSines(){
        float x = 10f;
        StartCoroutine(DoIt());
        while(x > 0){
            x -= Time.smoothDeltaTime;
            yield return null;
        }
       StopCoroutine(DoIt());
       Destroy(gameObject);
    }
    IEnumerator DoIt(){
        for(;;){
            Instantiate(SinosodalBulletObject, transform.position, Quaternion.LookRotation(Direction));
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
    public override void TakeDamage(int T){
        //do nothing
    }
}
