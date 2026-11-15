using UnityEngine;


public class lever : MonoBehaviour
{
    public combinedTileManager[] combinedTiles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Change();
        }
    }
    void Change()
    {
        for(int i = 0; i < combinedTiles.Length; i++)
        {
            if (combinedTiles[i].shadowTile.activeInHierarchy)
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
