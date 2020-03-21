using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    public Text countText;
    public Text timerText;
    public float timer;
    public float endtime = 0; 
    private int damage;
    public int damagepoints;
    public GameObject EndMenu;
    private int health;
    public AnimatorControllerParameter reachTower;
    public MainMenu mainmenu; 

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        
        health = 100;
        damage = 0;
        damagepoints = 20;
        SetCountText();
        
    }


   

    void Update()
    {
        
         timer = Mathf.Round(Time.timeSinceLevelLoad);
        SetTimerText();
        
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Goto cs = other.gameObject.GetComponent<Goto>();
            //Vector3.Distance(cs.startpos, Vector3(0, 0, 0));
            float survivetime = Time.time - cs.startTime;
            float distance = Vector3.Distance(cs.startpos, gameObject.transform.position);
            float avgspeed = distance / survivetime;
            Debug.Log("Survive time: " + survivetime.ToString() + " Distance: " + 
                distance.ToString() 
                + " avg speed: "+avgspeed.ToString() + " name: "+ cs.name);
            Debug.Log(Time.time - cs.startTime);
            damage += damagepoints;
            //print(damage);
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            SetCountText();
            EndGame();
            animator.SetBool("reachTower", true);

                       
        }
    }

    void SetCountText()
    {
        countText.text = "Tower health: " + (health - damage).ToString();
    }

    void SetTimerText()
    {
        timerText.text = "Time survived: " + timer.ToString();

    }


    void EndGame()
    {
        if ((health - damage) <= 0)
        {
            Debug.Log("You lost.....");
            endtime = timer;
            print("endtime = " + endtime);
            EndMenu.SetActive(true);
            timer = 0;
            
            Time.timeScale = 0;

        }

    }
}

