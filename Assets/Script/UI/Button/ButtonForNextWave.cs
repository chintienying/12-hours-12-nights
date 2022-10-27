using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonForNextWave : MonoBehaviour
{



    
    public void MoveToScene(int sceneID)    
    { 
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync(sceneID);

    }

}
