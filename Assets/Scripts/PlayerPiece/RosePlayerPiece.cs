using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosePlayerPiece : PlayerPiece
{

    private void OnMouseDown()
    {
        canMove = true;
        MoveSteps();
    }
}
