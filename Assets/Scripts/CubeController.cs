using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Subject
{
    public int coinsCollected;
    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    public float CurrentHealth
    {
        get { return health; }
    }

    private HUDController hudController;
    [SerializeField]
    private float health;

    private float distance = 500f;
    public Rigidbody rb;

    public void Awake()
    {
        hudController = gameObject.AddComponent<HUDController>();
    }

    public void Move(Direction direction)
    {
        if(direction == Direction.Left)
        {
            rb.MovePosition(Vector3.left * distance * Time.deltaTime);

        }
        if (direction == Direction.Right)
        {

            rb.MovePosition(Vector3.right * distance * Time.deltaTime);

        }
    }

    private void OnEnable()
    {
        if (hudController)
        {
            Attach(hudController);
        }
    }

    private void OnDisable()
    {
        if (hudController)
        {
            Detach(hudController);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            TakeDamage(10);
            NotifyObservers();
        }
        else
        {
            collision.gameObject.SetActive(false);
            coinsCollected++;
        }
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void ResetPosition()
    {
        rb.MovePosition(new Vector3(0.0f, 0.0f, 0.0f));
    }
}
