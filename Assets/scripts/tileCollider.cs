using UnityEngine;
using UnityEngine.SceneManagement;
public class tileCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("trigger");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
