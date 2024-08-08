using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed of the enemy movement
    public Animator animator;

    private Vector2 lastPlayerPosition; // Last known position of the player



    private void Start()
    {
        // Initialize the last player position
        lastPlayerPosition = player.position;
    }

    private void Update()
    {
        // Call the method to follow the player
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector2 direction = Vector2.zero;

        // Determine the direction to move in (X or Y axis) based on the player's movement
        if (Mathf.Abs(player.position.x - transform.position.x) > Mathf.Abs(player.position.y - transform.position.y))
        {
            // Move horizontally
            direction = new Vector2(Mathf.Sign(player.position.x - transform.position.x), 0);
        }
        else
        {
            // Move vertically
            direction = new Vector2(0, Mathf.Sign(player.position.y - transform.position.y));
        }

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        // Move the enemy in the chosen direction
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, moveSpeed * Time.deltaTime);

        // Update the last player position
        lastPlayerPosition = player.position;
    }
}
