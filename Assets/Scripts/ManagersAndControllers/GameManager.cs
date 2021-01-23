
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int numOfStepsToMove;
    public RollingDice rolledDice;
    List<PathPoint> playerOnPathPointsList = new List<PathPoint>();
    public bool canPlayMove = true;

    public  bool canDiceRoll = true;
    public bool transferDice = false;
    public bool selfDice = false;

    public int roseOutPlayers;
    public int blueOutPlayers;
    public int orangeOutPlayers;
    public int violetOutPlayers;

    public RollingDice[] manageRolingDice;
    
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

    public void RolingDiceManager()
    {
        int nextdice;
        if(GameManager.gm.transferDice)
        {
            for(int i=0; i<4; i++)
            {
                if(i==3){nextdice=0;}else { nextdice = i +1; }
                if(GameManager.gm.rolledDice == GameManager.gm.manageRolingDice[i])
                {
                    GameManager.gm.manageRolingDice[i].gameObject.SetActive(false);
                    GameManager.gm.manageRolingDice[nextdice].gameObject.SetActive(true);
                }
            }
            GameManager.gm.canDiceRoll = true;
        }else{
            if(GameManager.gm.selfDice)
            {
                GameManager.gm.selfDice = false;
                GameManager.gm.canDiceRoll = true;
            }
        }
    }
}
