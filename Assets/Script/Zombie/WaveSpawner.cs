using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    private Zombie zombie;
    public GameObject prefab;
    //private bool IsDead;
    //public Fence fence;
    

    
   
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    private int waveValue;


    public Transform[] spawnLocation;
    public int spawnIndex;

    public int waveDuration;
    public float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    //private bool IsActive = false;

    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public List<GameObject> killedEnemies = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
         currWave++;
        GenerateWave();
        //Instantiate prefab 
        //GameObject obj = Instantiate(prefab);
        //zombie = obj.GetComponent<Zombie>();
        //IsDead = zombie.IsDead;
        //fence = gameObject.GetComponent<Fence>();
        //Debug.Log(IsDead);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer <=0)
        {
            //spawn an enemy
            if(enemiesToSpawn.Count >0)
            {
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position,Quaternion.identity); // spawn first enemy in our list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;

                if(spawnIndex + 1 <= spawnLocation.Length-1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            else
            {
                waveTimer = 0; // if no enemies remain, end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

    //  晉級!
        if (waveTimer<=0 && spawnedEnemies.Count <=0)
        {
            //NextWave();
            SceneManager.LoadSceneAsync("SceneB");

        }


    }
    //crucial，SceneE結束請呼叫這個，進入下一關
    public void NextWave()
    {
        currWave++;
        GenerateWave(); 
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; // gives a fixed time between each enemies
        waveTimer = waveDuration; // wave duration is read only
    }

    public void GenerateEnemies()
    {

        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue>0 || generatedEnemies.Count <50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue<=0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }



    

}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}

