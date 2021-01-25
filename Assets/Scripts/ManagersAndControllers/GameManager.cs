
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

    public int roseCompletePlayers;
    public int blueCompletePlayers;
    public int orangeCompletePlayers;
    public int violetCompletePlayers;

    public RollingDice[] manageRolingDice;

    public PlayerPiece[] rosePlayerPiece;
    public PlayerPiece[] bluePlayerPiece;
    public PlayerPiece[] orangePlayerPiece;
    public PlayerPiece[] violetPlayerPiece;

    public int totalPlayerCanPlay;


    
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
            SiftDice();
            GameManager.gm.canDiceRoll = true;
        }else{
            if(GameManager.gm.selfDice)
            {
                GameManager.gm.selfDice = false;
                GameManager.gm.canDiceRoll = true;
            }
        }
    }

    void SiftDice(){

        int nextdice;

        if (GameManager.gm.totalPlayerCanPlay == 1) {

        }
        else if (GameManager.gm.totalPlayerCanPlay == 2) {

            if( GameManager.gm.rolledDice==GameManager.gm.manageRolingDice[0]){

                GameManager.gm.manageRolingDice[0].gameObject.SetActive(false);
                GameManager.gm.manageRolingDice[2].gameObject.SetActive(true);
            }

            else { 
                GameManager.gm.manageRolingDice[0].gameObject.SetActive(true);
                GameManager.gm.manageRolingDice[2].gameObject.SetActive(false);
            }

        }
        else if (GameManager.gm.totalPlayerCanPlay == 3) {

            for(int i=0; i<3; i++)
            {
                if(i==2){nextdice=0;}else { nextdice = i +1; }
                if(GameManager.gm.rolledDice == GameManager.gm.manageRolingDice[i])
                {
                    GameManager.gm.manageRolingDice[i].gameObject.SetActive(false);
                    GameManager.gm.manageRolingDice[nextdice].gameObject.SetActive(true);
                }
            }
            
        }
        else  {

            for(int i=0; i<4; i++)
            {
                if(i==3){nextdice=0;}else { nextdice = i +1; }
                if(GameManager.gm.rolledDice == GameManager.gm.manageRolingDice[i])
                {
                    GameManager.gm.manageRolingDice[i].gameObject.SetActive(false);
                    GameManager.gm.manageRolingDice[nextdice].gameObject.SetActive(true);
                }
            }
            
        }
    }
}
