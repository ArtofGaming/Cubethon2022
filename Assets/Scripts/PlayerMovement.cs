using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 50f;
    public Invoker _invoker;
    public bool _isReplaying;
    public bool _isRecording;
    public CubeController _cubeController;
    private Command _buttonA, _buttonD;

    // Start is called before the first frame update
    void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _cubeController = FindObjectOfType<CubeController>();
        _buttonA = new MoveLeft(_cubeController);
        _buttonD = new MoveRight(_cubeController);
    }

    private void Update()
    {
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                _invoker.ExecuteCommand(_buttonA);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _invoker.ExecuteCommand(_buttonD);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
