using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGunsController : MonoBehaviour
{
    public int count = 2;
    public GameObject shootAudio = null;
    // Start is called before the first frame update
    void Start()
    {
        selectbullet(0);
    }

    void selectbullet(int index)
    {
        for(var i = 0; i < transform.childCount; i++)
        {
            if( i == index)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(shootAudio != null)
            {
                Instantiate(shootAudio, Vector2.zero, Quaternion.identity);
            }
            count += 1;
            if(count % 2 == 0)
            {
                selectbullet(0);
            }
            else
            {
                selectbullet(1);
            }
        }
        
    }
}
