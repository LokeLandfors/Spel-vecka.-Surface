using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlide : MonoBehaviour
{

    public bool isSliding = false;
    public PlayerMovement PL;
    public Rigidbody2D rgb;
    public Animator anim;
    public BoxCollider2D regularCall;
    public BoxCollider2D slideCall;
    private bool canSlide = true;
    public float slidespeed = 1800f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            if (canSlide == true)
            {
                PerfromSlide();
            }
    }


    private void PerfromSlide()
    {
        isSliding = true;
        anim.SetBool("IsSlide", true);

        regularCall.enabled = false;
        slideCall.enabled = true;

        if (!PL.sprite.flipX)
        {
            rgb.AddForce(Vector2.right * slidespeed);
        }
        else
        {
            rgb.AddForce(Vector2.left * slidespeed);
        }
        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        canSlide = false;
        yield return new WaitForSeconds(0.8f);
        anim.Play("PlayerIdle");
        anim.SetBool("IsSlide", false);
        regularCall.enabled = true;
        slideCall.enabled = false;
        isSliding = false;
        yield return new WaitForSeconds(0.5f);
        canSlide = true;
    }

}
