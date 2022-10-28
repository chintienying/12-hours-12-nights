using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zombie : MonoBehaviour
{
    private Animator animator;
    public float speed = 3f;
    public int life = 7;
    private Fence rock;
    private PlayerLife playerLife;
    //------------------------------

    public float deadTime = 0.3f;
    public string anim = "state1";
    public int damage = 10;
    public bool IsDead;
    //------------------------------

    private GameObject Player;




    private Rigidbody2D rb;
   
    void Start()
    {
        rock = GameObject.Find("fence").GetComponent<Fence>();
        playerLife =  GameObject.Find("Player").GetComponent<PlayerLife>();
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        IsDead = false;
        Player = GameObject.Find("Player");
    }



        
    

    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("hit!");
        
    
        if(other.gameObject.CompareTag("fence"))
        {
            this.animator.SetInteger(anim, 1);
            rock.fenceHurt();
        }
        if(other.gameObject.CompareTag("Player"))
        {
            this.speed = 0f;
            this.animator.SetInteger(anim, 1);
            playerLife.PlayerTakeDamage(damage);
        }
         
    }
    

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);

        if (rock.isFencedestroyed)
        {
            speed = 0.3f;
            animator.SetInteger(anim, 3);
            transform.position = Vector2.MoveTowards(transform.position,Player.transform.position, speed*Time.deltaTime);
        }
        


        //dead
        if (life <= 0)
        {
            IsDead = true;
            Die();
        }
    }
    private void OnMouseDown()
    {
        speed = 0.2f;
        animator.SetInteger(anim, 2);
        life -= 1;
        if (deadTime > 0)
        {
            deadTime -= Time.deltaTime;
        }else
        {
            speed = 0.5f;
            this.animator.SetInteger(anim, 1);

        }

    }//hurt

    public void Die()
    {

     
            
            animator.SetInteger(anim, 4);
            speed = 0.0f;
            if (deadTime > 0)
            {
                deadTime -= Time.deltaTime;
            }
            
            else
            {
                Destroy(this.gameObject, 2);
                 
            }
        

    }
    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Remove(gameObject);
        }
    }



}
