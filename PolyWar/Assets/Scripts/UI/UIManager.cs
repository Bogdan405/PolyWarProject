using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void OnClickGoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


}
