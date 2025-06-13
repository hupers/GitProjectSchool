using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4PlanterScript : MonoBehaviour
{
    public Transform cam;
    public GameObject C4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            Instantiate(C4, transform.position, transform.rotation);
        }        
    }
    void LateUpdate()
    {
        transform.LookAt(cam);
        Vector3 angles = transform.eulerAngles;
        angles.x = 0f;
        transform.eulerAngles = angles;
    }
}
