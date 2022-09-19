
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement playerMovement;
    void OnTriggerEnter(Collider other)
    {
        playerMovement._cubeController.ResetPosition();
        playerMovement._isRecording = false;
        Debug.Log("Starting Replay");
        playerMovement._cubeController.ResetPosition();
        playerMovement._isReplaying = true;
        playerMovement._invoker.Replay();
        playerMovement._isReplaying = false;
        gameManager.CompleteLevel();
        playerMovement._cubeController.ResetPosition();
        playerMovement._isRecording = true;
    }

}
