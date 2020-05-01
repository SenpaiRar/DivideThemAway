using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Enemy : Enemy
{
    public Entity Target;
    public float Speed;
    public AudioClip DeathSound;
    public int Score;
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime*Speed);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Target.TakeDamage(1);
            Destroy(gameObject);
            //StartCoroutine(HitFreeze());
        }
    }
    public override void TakeDamage(int T)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Score_Manager>().AddScore(Score);
        Target.GetComponent<AudioSource>().PlayOneShot(DeathSound);
        Destroy(gameObject);
    }
    public override void SpawnRoutine(Vector3 T)
    {
        Instantiate(this.gameObject, new Vector3(T.x, 0, T.z), Quaternion.identity);        
    }
    
}
