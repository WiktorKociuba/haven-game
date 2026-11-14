using UnityEngine;

public class ShadowTile : MonoBehaviour
{
    public GameObject collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
