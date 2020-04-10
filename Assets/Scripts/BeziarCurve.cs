using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeziarCurve : MonoBehaviour
{
    Vector2 StartPoint;
    Vector2 EndPoint;
    Vector2 CurvePoint;

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
        
        StartPoint = new Vector2(FirstPoint.transform.position.x, FirstPoint.transform.position.z);
        EndPoint = new Vector2(SecondPoint.transform.position.x, SecondPoint.transform.position.z);
        CurvePoint  = new Vector2(ThirdPoint.transform.position.x, ThirdPoint.transform.position.z);
        
        p = Mathf.PingPong(Time.time, 1);
        Test.transform.position = new Vector3(CalculatePosition(p).x, 0,CalculatePosition(p).y);
    }

    Vector2 CalculatePosition(float t){
        Vector2 B;
        B = (Mathf.Pow(1-t,2)*StartPoint) + ((2*(1-t))*t*CurvePoint) + (Mathf.Pow(t,2)*EndPoint);
        return(B);
    }

}
