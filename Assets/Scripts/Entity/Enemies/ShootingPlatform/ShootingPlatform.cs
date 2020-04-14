using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlatform : Enemy
{
    
    GameObject Player;
    public int StartingHeatlth;
    public GameObject Bullet;
    Vector3[] NextTargets = new Vector3[2];
    Vector3 Direction;
    bool Recalculating;
    void Start()
    {
        Recalculating = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        NextTargets[0] = new Vector3(Random.Range(-26.7f, 26.7f), 0, Random.Range(-15f, 15f));
        NextTargets[1] = new Vector3(Random.Range(-26.7f, 26.7f), 0, Random.Range(-15f, 15f));
        Direction = NextTargets[1] - transform.position;

       
    }


    void Update()//26.7, 15 x z boundaries
    {
       /* if(!Recalculating)
            transform.position = Vector3.Lerp(transform.position, NextTargets[0], 0.1f);
        if(Vector3.Distance(transform.position, NextTargets[0]) < 0.5 && !Recalculating)
        {
            Debug.Log("Reached Target!");
            StartCoroutine(Recalculate());
        }
        */
        
        transform.rotation = Quaternion.LookRotation(Direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            other.GetComponent<Entity>().TakeDamage(1);
        }
    }

    public override void SpawnRoutine(Vector3 T)
    {
        Instantiate(this.gameObject, T, Quaternion.identity);
    }
    public override void TakeDamage(int T)
    {
        Debug.Log(StartingHeatlth);
        StartingHeatlth -= T;
        if(StartingHeatlth <= 0)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator Recalculate()
    {
        Recalculating = true;
        yield return new WaitForSecondsRealtime(2.0f);
        NextTargets[0] = NextTargets[1];
        NextTargets[1] = new Vector3(Random.Range(-26.7f, 26.7f), 0, Random.Range(-15f, 15f));
        Recalculating = false;
        yield return null;
    }
    IEnumerator ShootAtPlayer()
    {
        for (; ; )
        {
          Instantiate(Bullet, transform.position, Quaternion.LookRotation(Player.transform.position-transform.position));
          yield return new WaitForSeconds(5.0f);
          
        }
    }

}
