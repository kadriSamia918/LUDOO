using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
   public GameObject MainPanel ;
   public GameObject GamePanel ;
   public void Game1(){
       GameManager.gm.totalPlayerCanPlay=2;
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);
       Game1Setting();

   }
     public void Game2(){
         GameManager.gm.totalPlayerCanPlay=3;
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);
       Game2Setting();

   }

  public void Game3(){
      GameManager.gm.totalPlayerCanPlay=4;
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);

   }

 /* public void Game4(){
      GameManager.gm.totalPlayerCanPlay=1;
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);

   }
    */
   void Game1Setting() { 
       HidePlayers(GameManager.gm.bluePlayerPiece);
       HidePlayers(GameManager.gm.violetPlayerPiece);
   }

   void Game2Setting() { 
       
       HidePlayers(GameManager.gm.violetPlayerPiece);
   }

   void HidePlayers(PlayerPiece[] playerPieces_){

       for(int i= 0; i<playerPieces_.Length; i++) {

           playerPieces_[i].gameObject.SetActive(false);
       }

   }

}
