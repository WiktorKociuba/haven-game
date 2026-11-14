using UnityEngine;
using System.Collections;

public class buttonPress : MonoBehaviour
{
    public float durationOfPress;
    public combinedTileManager[] combinedTiles;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("here");
        if(other.CompareTag("Hand"))
        {
            Debug.Log("clicked");
            Change();
            StartCoroutine(buttonTimer());
        }
    }
    private IEnumerator buttonTimer(){
        yield return new WaitForSeconds(durationOfPress);
        Change();
        Debug.Log("Unclicked");
    }
    void Change(){
        for(int i = 0; i < combinedTiles.Length; i++)
        {
            if(combinedTiles[i].shadowTile.activeInHierarchy)
            {
                combinedTiles[i].shadowTile.SetActive(false);
                combinedTiles[i].lightTile.SetActive(true);
            }
            else
            {
                combinedTiles[i].shadowTile.SetActive(true);
                combinedTiles[i].lightTile.SetActive(false);
            }
        }
    }
}
