using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeziarCurve : MonoBehaviour
{
    Vector2 StartPoint;
    Vector2 EndPoint;
    Vector2 CurvePoint;
    Vector2 Derv;
    public GameObject FirstPoint;
    public GameObject SecondPoint;
    public GameObject ThirdPoint;
    public GameObject Test;
    float p;
    void Start(){
        StartPoint = new Vector2(FirstPoint.transform.position.x, FirstPoint.transform.position.z);
        EndPoint = new Vector2(SecondPoint.transform.position.x, SecondPoint.transform.position.z);
        CurvePoint  = new Vector2(ThirdPoint.transform.position.x, ThirdPoint.transform.position.z);
        p = 0;
    }

    void Update(){
        
        if(p<1){

        StartPoint = new Vector2(FirstPoint.transform.position.x, FirstPoint.transform.position.z);
        EndPoint = new Vector2(SecondPoint.transform.position.x, SecondPoint.transform.position.z);
        CurvePoint  = new Vector2(ThirdPoint.transform.position.x, ThirdPoint.transform.position.z);
        Derv = CalculateDerv(p);
        Test.transform.rotation = Quaternion.LookRotation(new Vector3(Derv.normalized.x, 0, Derv.normalized.y));
        Test.transform.position = new Vector3(CalculatePosition(p).x, 0,CalculatePosition(p).y);
        p = Mathf.PingPong(Time.time, 1);
       
        
    }
    void FixedUpdate(){
        

    }
    Vector2 CalculateDerv(float t){
        Vector2 D = ((2*(1-p)*(CurvePoint-StartPoint)) + 2*p*(EndPoint-CurvePoint) );
        return(D);
    }
    Vector2 CalculatePosition(float t){
        Vector2 B;
        B = (Mathf.Pow(1-t,2)*StartPoint) + ((2*(1-t))*t*CurvePoint) + (Mathf.Pow(t,2)*EndPoint);
        return(B);
    }
    }
}
