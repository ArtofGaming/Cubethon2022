using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Command
{
    private CubeController _controller;
    public MoveRight(CubeController cubeController)
    {
        _controller = cubeController;
    }

    public override void Execute()
    {
        _controller.Move(CubeController.Direction.Right);
    }
}
