using UnityEngine;
using System.Collections.Generic;

public class EnemyLearning : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed of the enemy movement
    public int memorySize = 5; // Number of past player positions to remember

    private Queue<Vector2> playerPositions; 

    private void Start()
    {
        
        playerPositions = new Queue<Vector2>(memorySize);

        // Fill the queue with the initial player position
        for (int i = 0; i < memorySize; i++)
        {
            playerPositions.Enqueue(player.position);
        }
    }

    private void Update()
    {
        // Call the method to learn and follow the player
        LearnAndFollowPlayer();
    }

    private void LearnAndFollowPlayer()
    {
        // Predict the player's next move based on the past positions
        Vector2 predictedPosition = PredictPlayerPosition();

        Vector2 direction = Vector2.zero;

        // Determine the direction to move in (X or Y axis) based on the predicted position
        if (Mathf.Abs(predictedPosition.x - transform.position.x) > Mathf.Abs(predictedPosition.y - transform.position.y))
        {
            // Move horizontally
            direction = new Vector2(Mathf.Sign(predictedPosition.x - transform.position.x), 0);
        }
        else
        {
            // Move vertically
            direction = new Vector2(0, Mathf.Sign(predictedPosition.y - transform.position.y));
        }

        // Move the enemy in the chosen direction
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, moveSpeed * Time.deltaTime);

        // Update the queue with the current player position
        playerPositions.Dequeue();
        playerPositions.Enqueue(player.position);
    }

    private Vector2 PredictPlayerPosition()
    {
        // Simple prediction: average of past positions
        Vector2 sum = Vector2.zero;
        foreach (Vector2 pos in playerPositions)
        {
            sum += pos;
        }
        return sum / playerPositions.Count;
    }
}
