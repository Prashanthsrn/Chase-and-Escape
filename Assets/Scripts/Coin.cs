using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner spawner;

    public void SetSpawner(CoinSpawner coinSpawner)
    {
        spawner = coinSpawner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Add code to increase player score
            Destroy(gameObject);
            spawner.CoinCollected();
        }
    }
}
