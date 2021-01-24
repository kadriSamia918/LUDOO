using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
   public GameObject MainPanel ;
   public GameObject GamePanel ;
   public void Game1(){
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);

   }
     public void Game2(){
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);

   }

  public void Game3(){
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);

   }

  public void Game4(){
       MainPanel.SetActive(false);
       GamePanel.SetActive(true);

   }

}
