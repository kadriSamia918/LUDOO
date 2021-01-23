using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VioletPlayerPiece : PlayerPiece
{
    RollingDice violetHomeRollingDice; 

    private void Start() 
    { 
        violetHomeRollingDice = GetComponentInParent<VioletHome>().rollingDice ; 
    }

    private void OnMouseDown()
    {
        if(GameManager.gm.rolledDice != null) 
        {
            if(!isReady)
            { 
                if (GameManager.gm.rolledDice == violetHomeRollingDice && GameManager.gm.numOfStepsToMove==6)
                {
                    GameManager.gm.violetOutPlayers += 1;
                    MakePlayerReadyToMove(pathsParent.violetPathPoint);
                    GameManager.gm.numOfStepsToMove = 0 ;
                    return;
                }
            }
            if(GameManager.gm.rolledDice == violetHomeRollingDice && isReady ) 
            {
                canMove = true;
            }
        }
        MoveSteps(pathsParent.violetPathPoint);
    }
}
