using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicBullet : Bullet
{
    Vector2 StartPoint;
    Vector2 EndPoint;
    Vector2 CurvePoint;
    Vector2 Derv;
    public GameObject FirstPoint;
    public GameObject SecondPoint;
    public GameObject ThirdPoint;
    public float Speed;
    public int Damage;
    
    float p;
    float tOff;

    private void Start(){
    p = 0;
    StartPoint = new Vector2(FirstPoint.transform.position.x, FirstPoint.transform.position.z);
    EndPoint = new Vector2(SecondPoint.transform.position.x, SecondPoint.transform.position.z);
    CurvePoint  = new Vector2(ThirdPoint.transform.position.x, ThirdPoint.transform.position.z);
    tOff = Time.time;
    }
    private void Update(){
        
        StartPoint = new Vector2(FirstPoint.transform.position.x, FirstPoint.transform.position.z);
        EndPoint = new Vector2(SecondPoint.transform.position.x, SecondPoint.transform.position.z);
        CurvePoint  = new Vector2(ThirdPoint.transform.position.x, ThirdPoint.transform.position.z);
        transform.position = new Vector3(CalculatePosition(p).x, 0, CalculatePosition(p).y);

            p = Mathf.PingPong((Time.time-tOff)*Speed, 1);

            if(p>0.9f){
                Destroy(gameObject);
            }
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Enemy" || col.tag=="Enemy_Bullet"){
            col.GetComponent<Entity>().TakeDamage(Damage);
        }
    }

    public override int GetDamage(){
        return Damage;
    }

    Vector2 CalculatePosition(float t){
        Vector2 B;
        B = (Mathf.Pow(1-t,2)*StartPoint) + ((2*(1-t))*t*CurvePoint) + (Mathf.Pow(t,2)*EndPoint);
        return(B);
    }
    
}
