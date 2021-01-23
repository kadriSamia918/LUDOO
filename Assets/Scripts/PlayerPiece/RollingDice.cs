using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int numberGot;
    [SerializeField] GameObject rollingDiceAnim;
    [SerializeField] SpriteRenderer numberedSpHoldere;
    [SerializeField] Sprite[] numberedSprites;

    Coroutine generateRandomNumOnDice_Coroutine;
    public int outPieces;

    private void OnMouseDown()
    {
        generateRandomNumOnDice_Coroutine = StartCoroutine(GenerateRandomNumberOnDice_Enum());
    }

    IEnumerator GenerateRandomNumberOnDice_Enum()
    {
        yield return new WaitForEndOfFrame();
        if(GameManager.gm.canDiceRoll)
        {
            GameManager.gm.canDiceRoll = false;
            numberedSpHoldere.gameObject.SetActive(false);
            rollingDiceAnim.SetActive(true);
            yield return new WaitForSeconds(1f);
            numberGot=Random.Range(0, 6);
            numberedSpHoldere.sprite = numberedSprites[numberGot];
            numberGot +=1;

            GameManager.gm.numOfStepsToMove = numberGot;
            GameManager.gm.rolledDice= this;


            numberedSpHoldere.gameObject.SetActive(true);
            rollingDiceAnim.SetActive(false);
            yield return new WaitForEndOfFrame();

            if(GameManager.gm.rolledDice == GameManager.gm.manageRolingDice[0]){ outPieces = GameManager.gm.roseOutPlayers;}
            else if(GameManager.gm.rolledDice == GameManager.gm.manageRolingDice[1]){ outPieces = GameManager.gm.blueOutPlayers;}
            else if(GameManager.gm.rolledDice == GameManager.gm.manageRolingDice[2]){ outPieces = GameManager.gm.orangeOutPlayers;}
            else if(GameManager.gm.rolledDice == GameManager.gm.manageRolingDice[3]){ outPieces = GameManager.gm.violetOutPlayers;} 
            if(GameManager.gm.numOfStepsToMove != 6 && outPieces == 0)
               {
                    GameManager.gm.canDiceRoll = true;
                    GameManager.gm.selfDice = false;
                    GameManager.gm.transferDice = true;
                    yield return new WaitForSeconds(0.5f);
                    GameManager.gm.RolingDiceManager();
               }
            


            if(generateRandomNumOnDice_Coroutine != null)
            {
                StopCoroutine(generateRandomNumOnDice_Coroutine);
            }
        }
    }
}
