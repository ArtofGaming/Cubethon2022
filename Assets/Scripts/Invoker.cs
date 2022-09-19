using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    
    private float _replayTime;
    private float _recordingTime;
    private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();
    public PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement._isRecording = true;
    }
    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (playerMovement._isRecording)
        {
            _recordedCommands.Add(_recordingTime, command);
        }

        Debug.Log("Recording Time: " + _recordingTime);
        Debug.Log("Recorded Command: " + command);
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        playerMovement._isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        playerMovement._isReplaying = true;

        if (_recordedCommands.Count <= 0)
        {
            Debug.LogError("No commands to replay");
        }

        _recordedCommands.Reverse();
    }

    void FixedUpdate()
    {
        if (playerMovement._isRecording)
        {
            _recordingTime += Time.fixedDeltaTime;
        }

        if (playerMovement._isReplaying)
        {
            _replayTime += Time.deltaTime;

            if (_recordedCommands.Any())
            {

                if(Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {
                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " + _recordedCommands.Values[0]);
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                playerMovement._isReplaying = false;
            }
        }
    }
}
