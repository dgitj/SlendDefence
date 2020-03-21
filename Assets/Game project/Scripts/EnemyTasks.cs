using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Panda;

public class EnemyTasks : MonoBehaviour
{
    public PlayerView playerview;
    public FindSafezone findsafezone;
    public Goto Goto;
    public Animator animator;
    public AudioSource audioSource;
    private bool invul;

    [Task]
    public bool Visible;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
       Visible = playerview.Seen;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (!invul && collision.transform.tag == "Arrow")
        {
            //Debug.Log(Time.time - Goto.startTime);
            invul = true; //player is invulnerable
            Destroy(collision.gameObject);
            animator.SetBool("falling", true);
            StartCoroutine(InvulWait());
            

        }
        if (invul && collision.transform.tag == "Arrow")
        {
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator InvulWait()
    {
        //animator.SetBool("notAttacked", false);
        //animator.SetBool("shooting", false);
        //animator.SetBool("falling", true);
        animator.SetTrigger("falling"); //play hit animation
        Goto.speed = 0;
        yield return new WaitForSeconds(2); //invul time
        Destroy(gameObject);
        invul = false;
        

    }

    //movement tasks
    [Task]
    public void Walk()
    {
        animator.SetBool("notAttacked", true);
        Task.current.Succeed();
    }
    [Task]
    public void Attack()
    {
        animator.SetBool("shooting", false);
        animator.SetBool("reachTower", true);
        
        Task.current.Succeed();
    }

    [Task]
    public void RunningShooting()
    {
        animator.SetBool("shooting", true);
        Task.current.Succeed();
    }

    [Task]
    public void Falling()
    {
        animator.SetBool("falling", true);
        Goto.speed = 0;
        Task.current.Succeed();
    }

    [Task]

    public void ResetVisibility()
    {
        animator.SetBool("falling", false);
        Visible = false;
        Task.current.Succeed();
    }

    [Task]
    public void Hide()
    {
            findsafezone.WalkToSafezone();
            findsafezone.ResetVisibility();
    }

    [Task]
    public void Scream()
    {
        audioSource.Play();
    }

  

}

