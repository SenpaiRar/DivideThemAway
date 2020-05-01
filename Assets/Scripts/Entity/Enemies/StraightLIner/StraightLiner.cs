using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLiner : Enemy
{
    GameObject Target;  
    Vector3 Direction;  
    public float Speed;
    public float TimeTillDeath; //How long until self-destruct
    public AudioClip DeathSound;
    public int Damage;
    public int Score;
    private void Start(){
        StartCoroutine(Lifespan());
        Target=GameObject.FindWithTag("Player");
        Direction = Target.transform.position-transform.position;
        
    }

    private void Update(){
        transform.Translate(Direction.normalized*Speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
           col.GetComponent<Entity>().TakeDamage(Damage);
           Destroy(gameObject);
        }
    }
    public override void TakeDamage(int T){
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Score_Manager>().AddScore(Score);
        Target.GetComponent<AudioSource>().PlayOneShot(DeathSound);
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
