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

    public void MoveSteps()
    {
        moveSteps_Coroutine = StartCoroutine(MoveSteps_Enum());
    }

    public void MakePlayerReadyToMove() 
    {
        isReady=true;
        transform.position =pathsParent.commonPathPoints[0].transform.position; 

    }






    IEnumerator MoveSteps_Enum()
    {
        yield return new WaitForSeconds(0.25f);
        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;
        
        if (canMove)
        {
            for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + numOfStepsToMove); i++)
            {
               transform.position=pathsParent.commonPathPoints[i].transform.position;
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

