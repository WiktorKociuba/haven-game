using UnityEngine;
using UnityEngine.SceneManagement;

public class doorCollider : MonoBehaviour
{
    public int sceneNumber;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
