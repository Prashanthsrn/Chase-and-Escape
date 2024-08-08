using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; 
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    private GameObject currentCoin;

    private void Start()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        currentCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        Coin coinScript = currentCoin.GetComponent<Coin>();
        if (coinScript != null)
        {
            coinScript.SetSpawner(this);
        }
    }

    public void CoinCollected()
    {
        currentCoin = null;
        SpawnCoin();
    }
}
