using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fence : MonoBehaviour, IDataPersistence
{

    public int barricadeDamage = 100;
    public bool isFencedestroyed = false;
    private BoxCollider2D bc;
    private Rigidbody2D rb;

    [SerializeField] private float strength = 16f, delay = 0.15f;

    public int minusBlood = 5;
    //public int barricadeDamage = 0; //紀錄護欄損血

    


    public void LoadData(GameData data)
    {
        this.barricadeDamage = data.barricadeDamage;

    }

    public void SaveData(ref GameData data)
    {
       data.barricadeDamage = this.barricadeDamage;
    }
    
    private void Start()
    {
        isFencedestroyed = false;
        bc = gameObject.GetComponent<BoxCollider2D>();
        GameEventManager.instance.onBarricadeDamaged += fenceHurt;

        
    }

    private void OnDestroy()
    {
        GameEventManager.instance.onBarricadeDamaged -= fenceHurt;

    }

    void Update()
    {
        if (barricadeDamage <= 0)
        {
            isFencedestroyed = true;
            bc.enabled = false;
            
        }
        


    }
    public void fenceHurt()
    {
        barricadeDamage -= minusBlood;
    }












    private void OnTriggerEnter2D(Collider2D other) 
    {
            
        if(other.gameObject.CompareTag("zombie"))
        {
            Rigidbody2D zombie = other.GetComponent<Rigidbody2D>();
            if (zombie != null){
                zombie.isKinematic = false;
                Vector2 direction = new Vector2(-1f, 0).normalized;
                zombie.AddForce(direction*strength, ForceMode2D.Impulse);
                StartCoroutine(Reset(zombie));

            }
        }
            
    }
    
    private IEnumerator Reset(Rigidbody2D zombie) 
    {
       if(zombie != null)
       {
            yield return new WaitForSeconds(delay);
            zombie.velocity = Vector2.zero;
            zombie.isKinematic = true;

       }
    }



    

}
