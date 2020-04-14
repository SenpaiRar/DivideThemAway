using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLiner : Enemy
{
    Vector3 Target;  
    Vector3 Direction;  
    public float Speed;
    public float TimeTillDeath; //How long until self-destruct
    public int Damage;
    private void Start(){
        StartCoroutine(Lifespan());
        Target=GameObject.FindWithTag("Player").transform.position;
        Direction = Target-transform.position;
    }

    private void Update(){
        transform.Translate(Direction.normalized*Speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            col.GetComponent<Entity>().TakeDamage(Damage);
        }
    }
    public override void TakeDamage(int T){
        Destroy(gameObject);
    }
    public override void SpawnRoutine(Vector3 T){
        Instantiate(this.gameObject, new Vector3(T.x,0,T.z), Quaternion.identity);
    }
    IEnumerator Lifespan(){
        yield return new WaitForSecondsRealtime(TimeTillDeath);
        Destroy(gameObject);
    }
}
