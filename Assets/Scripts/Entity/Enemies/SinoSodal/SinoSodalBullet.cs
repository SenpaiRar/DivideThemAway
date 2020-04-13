using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SinoSodalBullet : MonoBehaviour
{
    public float Speed;
    
    private void Start(){
        StartCoroutine(LifeSpawn());
    }
    private void Update(){
        transform.Translate(Vector3.forward*Time.deltaTime*Speed, Space.Self);
    }
    IEnumerator LifeSpawn(){
        yield return new WaitForSecondsRealtime(10.0f);
        Destroy(gameObject);
    }
}