using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneBTransition : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoading = 5f;
    [SerializeField] private string sceneNameToLoad;

    private float timeElapsed;


    // Start is called before the first frame update
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadSceneAsync(sceneNameToLoad);
        }
        
    }

}
