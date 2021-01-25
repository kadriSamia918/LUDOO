using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    PathPoint [] pathpointToMoveon_;
    public PathObjectParent pathObjParent;
    public List<PlayerPiece> playerPiecesList = new List<PlayerPiece>();



    private void Start()
    {
        pathObjParent = GetComponentInParent<PathObjectParent>();
    }
    public bool AddPlayerPiece(PlayerPiece playerPiece_)
    {
        if (this.name=="CenterHomePoint") { Compled(playerPiece_);}

         if(this.name != "PathPoint" && this.name != "PathPoint (8)" &&this.name != "PathPoint (13)" &&this.name != "PathPoint (21)" &&this.name != "PathPoint (26)" &&this.name != "PathPoint (34)"
         && this.name != "PathPoint (39)" && this.name != "PathPoint (47)" && this.name != "CenterHomePoint"){
        if(playerPiecesList.Count == 1)
        {
            string preePlayerPiceName = playerPiecesList[0].name;
            string curntPlayerPiceName = playerPiece_.name;
            curntPlayerPiceName = curntPlayerPiceName.Substring(0, curntPlayerPiceName.Length-4);

            if(!preePlayerPiceName.Contains(curntPlayerPiceName))
            {
               playerPiecesList[0].isReady = false;
               
               StartCoroutine(revertOnStart(playerPiecesList[0])) ;

               playerPiecesList[0].numberOfStepsAlreadyMoved = 0;
               RemovePlayerPiece(playerPiecesList[0]);
               playerPiecesList.Add(playerPiece_);
               return false;
            }
        }
         }
        AddPlayer(playerPiece_);
        return true;
    }

    IEnumerator revertOnStart(PlayerPiece playerPiece_)
    {
        if(playerPiece_.name.Contains("Rose")){GameManager.gm.roseOutPlayers -= 1; pathpointToMoveon_= pathObjParent.rosePathPoint;}
        else if(playerPiece_.name.Contains("Blue")){GameManager.gm.blueOutPlayers -= 1; pathpointToMoveon_= pathObjParent.bluePathPoint;}
        else if(playerPiece_.name.Contains("Orange")){GameManager.gm.orangeOutPlayers -= 1; pathpointToMoveon_= pathObjParent.orangePathPoint;}
        else if(playerPiece_.name.Contains("Violet")){GameManager.gm.violetOutPlayers -= 1; pathpointToMoveon_= pathObjParent.violetPathPoint;}
        
        for(int i = playerPiece_.numberOfStepsAlreadyMoved; i>=0; i-- )
        {
            playerPiece_.transform.position = pathpointToMoveon_[i].transform.position;
            yield return new WaitForSeconds(0.02f);
        }

        playerPiece_.transform.position =pathObjParent.BasePoint[BasePointPosition(playerPiece_.name)].transform.position;
    }

    int BasePointPosition(string name)
    {
        for(int i =0; i<pathObjParent.BasePoint.Length; i++)
        {
            if(pathObjParent.BasePoint[i].name == name)
            {
                return i;
            }
        }
        return -1;
    }

    public void AddPlayer(PlayerPiece playerPiece_)
    {
        playerPiecesList.Add(playerPiece_);
        RescaleAndRespositionAllPlayerPieces();
    }
    
    public void RemovePlayerPiece(PlayerPiece playerPiece_)
    {
        
        if(playerPiecesList.Contains(playerPiece_))
        {
            playerPiecesList.Remove(playerPiece_);

        }
    }

    private void Compled(PlayerPiece playerPiece_) {

        if(playerPiece_.name.Contains("Rose")){GameManager.gm.roseCompletePlayers += 1;GameManager.gm.roseOutPlayers -= 1; if(GameManager.gm.roseCompletePlayers==4) {ShowCelibration();}}
        else if(playerPiece_.name.Contains("Blue")){GameManager.gm.blueCompletePlayers += 1; GameManager.gm.blueOutPlayers -= 1; if(GameManager.gm.blueCompletePlayers==4) {ShowCelibration();}}
        else if(playerPiece_.name.Contains("Orange")){GameManager.gm.orangeCompletePlayers += 1;GameManager.gm.orangeOutPlayers -= 1; if(GameManager.gm.orangeCompletePlayers==4) {ShowCelibration();}}
        else if(playerPiece_.name.Contains("Violet")){GameManager.gm.violetCompletePlayers += 1;GameManager.gm.violetOutPlayers -= 1; if(GameManager.gm.violetCompletePlayers==4) {ShowCelibration();}}

    }

    void ShowCelibration(){

    }
    
   public void RescaleAndRespositionAllPlayerPieces()
    {

        int plsCount = playerPiecesList.Count;
        bool isOdd;
        int spriteLayers = 0;
        if (plsCount%2 ==0)
        {
            isOdd = false;
        }
        else
        {
            isOdd = true;
        }
        int extent = plsCount / 2;
        int counter = 0;
       
        if(isOdd)
        {
            for(int i=-extent;i<=extent;i++)
            {
                playerPiecesList[counter].transform.localScale = new Vector3(pathObjParent.scales[plsCount -1],pathObjParent.scales[plsCount -1 ],1f);
                playerPiecesList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjParent.positionsDifference[plsCount - 1]), transform.position.y, 0f);
                counter++;

            }
        }
        else
        {
            for (int i = -extent; i <extent; i++)
            {
                playerPiecesList[counter].transform.localScale = new Vector3(pathObjParent.scales[plsCount - 1], pathObjParent.scales[plsCount - 1], 1f);
                playerPiecesList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjParent.positionsDifference[plsCount - 1]), transform.position.y, 0f);
                counter++;

            }
        }
        for(int i=0;i<playerPiecesList.Count;i++)
        {
            playerPiecesList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = spriteLayers;
            spriteLayers++;
        }
    }

}
