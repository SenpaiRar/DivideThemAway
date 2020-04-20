using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingPlatform : Enemy
{
    
    GameObject Player;
    public int StartingHeatlth;
    public GameObject Bullet;
    public float WaitTime;
    public Text BodyText;
    public Color HitColor;
    public AudioClip DamageSound;
    AudioSource Audiosrc;
    Vector3[] NextTargets = new Vector3[2];
    Vector3 Direction;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        NextTargets[0] = new Vector3(Random.Range(-26.7f, 26.7f), 0, Random.Range(-15f, 15f));
        NextTargets[1] = new Vector3(Random.Range(-26.7f, 26.7f), 0, Random.Range(-15f, 15f));
        Direction = NextTargets[1] - transform.position;
        Audiosrc = GetComponent<AudioSource>();

        StartCoroutine(Move());
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
        Audiosrc.PlayOneShot(DamageSound);
        StartCoroutine(HitSignal());
        StartingHeatlth -= T;
        if(StartingHeatlth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Move()
    {
        for (; ; )
        {
            if (Vector3.Distance(transform.position, NextTargets[0]) < 0.5)
            {
                
                NextTargets[0] = NextTargets[1];
                NextTargets[1] = new Vector3(Random.Range(-26.7f, 26.7f), 0, Random.Range(-15f, 15f));
                ShootAtPlayer();
                yield return new WaitForSecondsRealtime(WaitTime);
            }
            Direction = NextTargets[1] - transform.position;
            transform.position = Vector3.Lerp(transform.position, NextTargets[0], 0.1f);
            transform.rotation = Quaternion.LookRotation(Direction);
            yield return new WaitForEndOfFrame();
        }
    }

    public void ShootAtPlayer()
    {
        Vector3 x = Player.transform.position - transform.position;
        Instantiate(Bullet, transform.position, Quaternion.identity);
          
    }
    IEnumerator HitSignal(){
        BodyText.color = HitColor;
        yield return new WaitForSecondsRealtime(0.1f);
        BodyText.color = Color.black;
        yield return null;
    }
}
