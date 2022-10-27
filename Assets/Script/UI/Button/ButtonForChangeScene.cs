using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonForChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveToScene(int sceneID)
    {
        
        
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync(sceneID);
    }
}
