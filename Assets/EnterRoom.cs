using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRoom : MonoBehaviour
{
    public string tagName;
    public StringValue getMapName;
    private string sceneName;

    void OnTriggerEnter(Collider col)
    {
        sceneName = getMapName.text;
        SceneManager.LoadScene(sceneName);
    }

}
