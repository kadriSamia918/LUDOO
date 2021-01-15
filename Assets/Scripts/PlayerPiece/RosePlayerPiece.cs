using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosePlayerPiece : PlayerPiece
{
    RollingDice roseHomeRollingDice; 

    private void Start() 
    { 
        roseHomeRollingDice = GetComponentInParent<RoseHome>().rollingDice ; 
    }

    private void OnMouseDown()
    {
        if(GameManager.gm.rolledDice != null) 
        {
            if(!isReady)
            { 
                if (GameManager.gm.rolledDice == roseHomeRollingDice && GameManager.gm.numOfStepsToMove==6)
                {
                    MakePlayerReadyToMove(pathsParent.rosePathPoint);
                    GameManager.gm.numOfStepsToMove = 0 ;
                    return;
                }
            }
            if(GameManager.gm.rolledDice == roseHomeRollingDice && isReady ) 
            {
                canMove = true;
            }
        }
        MoveSteps(pathsParent.rosePathPoint);
    }

}
