using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPiece : MonoBehaviour
{
    public bool isReady;
    public bool canMove;
    public bool moveNow;
    public int numberOfStepsAlreadyMoved;
   
    public PathObjectParent pathsParent;

    Coroutine moveSteps_Coroutine;

    private void Awake()
    {
        pathsParent =FindObjectOfType<PathObjectParent>();
    }

    public void MoveSteps(PathPoint[] pathPointsToMoveOn_)
    {
        moveSteps_Coroutine = StartCoroutine(MoveSteps_Enum(pathPointsToMoveOn_));
    }

    public void MakePlayerReadyToMove(PathPoint[] pathPointsToMoveOn_) 
    {
        isReady=true;
        transform.position =pathPointsToMoveOn_[0].transform.position; 
        numberOfStepsAlreadyMoved = 1;

    }






    IEnumerator MoveSteps_Enum(PathPoint[] pathPointsToMoveOn_)
    {
        yield return new WaitForSeconds(0.25f);
        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;
        
        if (canMove)
        {
            for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + numOfStepsToMove); i++)
            {
               transform.position=pathPointsToMoveOn_[i].transform.position;
                yield return new WaitForSeconds(0.25f);
            }
        }

        numberOfStepsAlreadyMoved += numOfStepsToMove;
        if(moveSteps_Coroutine != null)
        {
            StopCoroutine(moveSteps_Coroutine);
        }


    }
}

