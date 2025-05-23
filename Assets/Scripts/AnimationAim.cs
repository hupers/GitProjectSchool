using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAim : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", true);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Walk", false);
        }
        //GetMouseButton1
        if(Input.GetMouseButton(1))
        {
            anim.SetBool("Aim", true);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Aim", false);
        }

        if(Input.GetKey(KeyCode.C))
        {
            anim.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Crouch", false);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("Rig|Pistol_Reload");
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.C))
        {
            anim.SetBool("CrouchWalking", true);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.C))
        {
            
            anim.SetBool("CrouchWalking", false);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Run", false);
        }
        if(Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {
            anim.Play("Rig|Pistol_Shoot");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Rig|Jump_Start");
        }
    }
    public void WalkAnim()
    {
        anim.SetBool("Walk", true);
    }
    public void StopWalkAnim()
    {
        anim.SetBool("Walk", false);
    }
    public void CrouchAim()
    {
        anim.SetBool("Crouch", true);
    }
    public void CrouchStopAim()
    {
        anim.SetBool("Crouch", false);
    }
}
