using UnityEngine;
using UnityEngine.SceneManagement;
public class menuManager : MonoBehaviour
{
    public Behaviour[] movementProviders;
    public void restartLevel()
    {
        foreach(var provider in movementProviders)
        {
            provider.enabled = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
