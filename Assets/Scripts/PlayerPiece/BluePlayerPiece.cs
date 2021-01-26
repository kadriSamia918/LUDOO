using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//blue

public class BluePlayerPiece : PlayerPiece
{
    RollingDice blueHomeRollingDice; 

    private void Start() 
    { 
        blueHomeRollingDice = GetComponentInParent<BlueHome>().rollingDice ; 
    }

    private void OnMouseDown()
    {
        if(GameManager.gm.rolledDice != null) 
        {
            if(!isReady)
            { 
                if (GameManager.gm.rolledDice == blueHomeRollingDice && GameManager.gm.numOfStepsToMove==6)
                {
                    GameManager.gm.blueOutPlayers += 1;
                    MakePlayerReadyToMove(pathsParent.bluePathPoint);
                    GameManager.gm.numOfStepsToMove = 0 ;
                    return;
                }
            }
            if (GameManager.gm.rolledDice == blueHomeRollingDice && isReady)
            {
                canMove = true;

            }
            else
                canMove = false;
        }
        MoveSteps(pathsParent.bluePathPoint);
    }
}
