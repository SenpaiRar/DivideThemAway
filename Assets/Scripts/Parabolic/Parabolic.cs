using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabolic : MonoBehaviour
{
    float TimePast;
    public float Multi;
    
    Vector3 B;

    float DistanceToX;
    float PrevDistanceToX;

    private void Start()
    {
        B = transform.position;
        PrevDistanceToX = 0;
    }
    private void Update()
    {
      
        transform.Translate((Vector3.forward*Time.deltaTime));
        DistanceToX = Mathf.Sqrt(Vector3.Distance(B, transform.position));
        transform.Translate(Vector3.right * Time.deltaTime * (DistanceToX - PrevDistanceToX));
        Debug.Log(Vector3.Distance(B, transform.position));
        //Debug.Log(DistanceToX - PrevDistanceToX);
        PrevDistanceToX = DistanceToX;
       
    }
}
