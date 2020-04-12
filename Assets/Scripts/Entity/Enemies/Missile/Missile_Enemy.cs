using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Enemy : Enemy
{
    public Entity Target;
    public float Speed;
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
            //StartCoroutine(HitFreeze());
        }
    }
    public override void TakeDamage(int T)
    {
        Destroy(gameObject);
    }
    public override void SpawnRoutine()
    {
        
            float x = Random.Range(30f, 40f);
            float z = Random.Range(30f, 40f);
        
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(this.gameObject, new Vector3(x, 0, z), Quaternion.identity);
            }
            else
            {
                Instantiate(this.gameObject, new Vector3(x, 0, -z), Quaternion.identity);
            }
        
    }
    //TODO: Hitstun
    /*IEnumerator HitFreeze()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
        Destroy(gameObject);
    }*/
}
