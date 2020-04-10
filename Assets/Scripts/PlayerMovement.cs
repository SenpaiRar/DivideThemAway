using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody PlayerBody;
    public float Speed;
    public float FrictionalForce;
    public Camera PlayerCam;
    private void FixedUpdate()
    {
        Vector3 RotVec = new Vector3(PlayerCam.ScreenToWorldPoint(Input.mousePosition).x, 0, PlayerCam.ScreenToWorldPoint(Input.mousePosition).z);
        transform.LookAt(RotVec);
        Vector3 x = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        PlayerBody.AddForce((x*Speed));
        PlayerBody.AddForce(-PlayerBody.velocity*PlayerBody.velocity.magnitude*FrictionalForce);
    }
}
