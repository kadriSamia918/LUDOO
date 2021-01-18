﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPiece : MonoBehaviour
{
    public bool isReady;
    public bool canMove;
    public bool moveNow;
    public int numberOfStepsAlreadyMoved;
   
    public PathObjectParent pathsParent;
    public PathPoint previousPathPoint;
    public PathPoint currentPathPoint;


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

        previousPathPoint = pathPointsToMoveOn_[0];
        currentPathPoint =pathPointsToMoveOn_[0];
        GameManager.gm.RemovePathPoint(previousPathPoint);
        GameManager.gm.AddPathPoint(currentPathPoint);

    }

    




    IEnumerator MoveSteps_Enum(PathPoint[] pathPointsToMoveOn_)
    {
        yield return new WaitForSeconds(0.25f);
        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;
        
        if (canMove)
        {
            for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + numOfStepsToMove); i++)
            {
                if(isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
                {
                    transform.position=pathPointsToMoveOn_[i].transform.position;
                    GameManager.gm.RemovePathPoint(pathPointsToMoveOn_[i]);
                    yield return new WaitForSeconds(0.25f);
                }
            }
        }
        if(isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
        {
               numberOfStepsAlreadyMoved += numOfStepsToMove;

               GameManager.gm.RemovePathPoint(previousPathPoint);
               previousPathPoint.RemovePlayerPiece(this);
               currentPathPoint = pathPointsToMoveOn_[numberOfStepsAlreadyMoved - 1];
               currentPathPoint.AddPlayerPiece(this);
               GameManager.gm.AddPathPoint(currentPathPoint);
               previousPathPoint = currentPathPoint;
        }

        if(moveSteps_Coroutine != null)
        {
            StopCoroutine(moveSteps_Coroutine);
        }


    }
    
    bool isPathPointsAvailableToMove(int numOfStepsToMove_, int numberOfStepsAlreadyMoved_, PathPoint[] pathPointsToMoveOn_)
    {
        int leftNumOfPathPoints = pathPointsToMoveOn_.Length - numberOfStepsAlreadyMoved_;
        if(leftNumOfPathPoints >= numOfStepsToMove_)
        {
            return true;

        }
        return false;
    }
}

