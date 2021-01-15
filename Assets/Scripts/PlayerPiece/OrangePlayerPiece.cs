using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePlayerPiece : PlayerPiece
{
    RollingDice orangeHomeRollingDice; 

    private void Start() 
    { 
        orangeHomeRollingDice = GetComponentInParent<OrangeHome>().rollingDice ; 
    }

    private void OnMouseDown()
    {
        if(GameManager.gm.rolledDice != null) 
        {
            if(!isReady)
            { 
                if (GameManager.gm.rolledDice == orangeHomeRollingDice && GameManager.gm.numOfStepsToMove==6)
                {
                    MakePlayerReadyToMove(pathsParent.orangePathPoint);
                    GameManager.gm.numOfStepsToMove = 0 ;
                    return;
                }
            }
            if(GameManager.gm.rolledDice == orangeHomeRollingDice && isReady ) 
            {
                canMove = true;
            }
        }
        MoveSteps(pathsParent.orangePathPoint);
    }
}
