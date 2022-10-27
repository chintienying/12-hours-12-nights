using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerLife : MonoBehaviour
{
    public int health ;
    public int maxHealth = 50;
    //public HealthBar healthBar;



    
    private Animator anim;
    private Rigidbody2D rb;
    



    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        

    }

    public void PlayerTakeDamage(int amount)
    {
        health -= amount;
        anim.SetTrigger("Hurt");
        //healthBar.SetHealth(health);
        
        if(health <= 0)
        {
            Die();
        }
        
    }

    public void Die()
    {
        anim.SetBool("IsDead",true);
        rb.bodyType = RigidbodyType2D.Static;
        SceneManager.LoadSceneAsync("GameOver");

    }

    public void Survive()
    {
        SceneManager.LoadSceneAsync("SceneB");

    }
}
