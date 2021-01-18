
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int numOfStepsToMove;

    public RollingDice rolledDice;

    List<PathPoint> playerOnPathPointsList = new List<PathPoint>();

    private void Awake()
    {
        gm = this;
    }
    
    public void AddPathPoint(PathPoint pathPoint_)
    {
        playerOnPathPointsList.Add(pathPoint_);
    }
    
    public void RemovePathPoint(PathPoint pathPoint_)
    {
        if(playerOnPathPointsList.Contains(pathPoint_))
        {
            playerOnPathPointsList.Remove(pathPoint_);
        }
        else
        {
            Debug.Log("Path point to found to be removed.");
        }
    }
}
