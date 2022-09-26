
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public int coinsCollected;
    /*void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            coinsCollected++;
        }

    }*/
}
