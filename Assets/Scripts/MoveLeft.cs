using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft :  Command
    { 
    private CubeController _controller;
    
    public MoveLeft(CubeController cubeController) 
    {
        _controller = cubeController;
    }

    public override void Execute()
    {
        _controller.Move(CubeController.Direction.Left);
    }
}
