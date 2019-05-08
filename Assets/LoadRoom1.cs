using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRoom1 : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        {
            SceneManager.LoadScene("Room2");
        }
    }
}
