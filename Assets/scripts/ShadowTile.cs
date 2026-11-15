using UnityEngine;
using UnityEngine.SceneManagement;
public class ShadowTile : MonoBehaviour
{
    public GameObject collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("trigger");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!playerType.isGracePeriod)
        {
            if(playerType.isLight){
                collider.SetActive(true);
            }
            else{
                collider.SetActive(false);
            }
        }
        else{
            collider.SetActive(false);
        }
    }
}
