using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform _object;
    private Vector3 _direction;

    public MoveCommand(Transform objectToMove, Vector3 direction)
    {
        _object = objectToMove;
        _direction = direction;
    }

    public void Execute()
    {
        _object.position += _direction;
    }

}
