using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    public List<PlayerPiece> playerPieces = new List<PlayerPiece>();
    public void AddPlayerPiece(PlayerPiece playerPiece_)
    {
        playerPieces.Add(playerPiece_);
    }
    
    public void RemovePlayerPiece(PlayerPiece playerPiece_)
    {
        
        if(playerPieces.Contains(playerPiece_))
        {
            playerPieces.Remove(playerPiece_);

        }
    }
    
        

}
