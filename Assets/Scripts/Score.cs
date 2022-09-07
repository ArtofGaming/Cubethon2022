
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public PlayerCollision playerCollision;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerCollision.coinsCollected.ToString();
    }
}
