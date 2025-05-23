using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
 private Rigidbody rb;
 private float speed = 5f;




private void Awake(){
    rb = GetComponent<Rigidbody>();
}

public void TakeForce(Transform target){
   Vector3 dir =  target.position - transform.position;
   rb.AddForce(dir * speed, ForceMode.Impulse);
   }
}
