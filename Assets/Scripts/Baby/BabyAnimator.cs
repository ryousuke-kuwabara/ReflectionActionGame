using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BabyAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }

    public void RotateToOriginal(float time)
    {
        Quaternion originalRotation = this.transform.rotation;
        StartCoroutine(ChangeRotateTo(originalRotation, time));
    }

    IEnumerator ChangeRotateTo(Quaternion rotation, float time)
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        yield return new WaitForSeconds(time);
        this.transform.rotation = rotation;
    } 

    public void StartCrawl()
    {
        this.animator.SetBool("isCrawling", true);
    }

    public void StopCrawl()
    {
        this.animator.SetBool("isCrawling", false);
    }

    public void StartIdle()
    {
        this.animator.SetBool("isIdle", true);
    }

    public void StopIdle()
    {
        this.animator.SetBool("isIdle", false);
    }

    public void StartRattle()
    {
        this.animator.SetBool("isRattle", true);
    }

    public void StopRattle()
    {
        this.animator.SetBool("isRattle", false);
    }

    public void StartTissue()
    {
        this.animator.SetBool("isTissue", true);
    }

    public void StopTissue()
    {
        this.animator.SetBool("isTissue", false);
    }

    public void StartBottle()
    {
        this.animator.SetBool("isBottle", true);
    }

    public void StopBottle()
    {
        this.animator.SetBool("isBottle", false);
    }

    public void StartMic()
    {
        this.animator.SetBool("isMic", true);
    }

    public void StopMic()
    {
        this.animator.SetBool("isMic", false);
    }

    public void StartCar()
    {
        this.animator.SetBool("isCar", true);
    }

    public void StopCar()
    {
        this.animator.SetBool("isCar", false);
    }

    public void StartWalker()
    {
        this.animator.SetBool("isWalker", true);
    }

    public void StopWalker()
    {
        this.animator.SetBool("isWalker", false);
    }
}
