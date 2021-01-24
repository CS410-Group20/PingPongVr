using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] private Transform _rocket;
    [SerializeField] private float _axisXWeight;
    [SerializeField] private float _axisYWeight;
    [SerializeField] private float _axisZWeight;
    [SerializeField] private float _hitForceWeight;
    
    
    private float x = 0;
    private float y = 0;
    private float z = 0;

    private void Start()
    {
        
    }

    public void Update()
    {
         x += GetAxisWeight("Mouse X", _axisXWeight);
         y += GetAxisWeight("Mouse Y", _axisYWeight);
         z += GetAxisWeight("Mouse Y", _axisZWeight);
         _rocket.position = new Vector3(x, y+_rocket.position.y, z);
         _rocket.rotation = Quaternion.Euler(0, 0,GetAngle());
         
    }

    private float GetAngle()
    {
        var direction = Vector3.down - _rocket.position;
        var directionProj = Vector3.ProjectOnPlane(direction, Vector3.forward);
        var reflaction = Vector3.Reflect(direction,Vector3.up);
        var reflactionProj = Vector3.ProjectOnPlane(Vector3.down-reflaction, Vector3.forward);

        var angle = Vector3.SignedAngle(reflactionProj, directionProj,Vector3.forward);
        return angle;
    }
    private float GetAxisWeight(string axisName, float axisWeight)
    {
        return Input.GetAxis(axisName) * axisWeight * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(GetAxisWeight("Mouse X", _axisXWeight),
            0,
            GetAxisWeight("Mouse Y", _axisZWeight))*_hitForceWeight;
    }

    
}