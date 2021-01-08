using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosePlayerPiece : PlayerPiece
{
    // Start is called before the first frame update
    private void Start()
    {

        //MoveSteps();
    }
    private void OnMouseDown()
    {
        canMove = true;
        StartCoroutine("MoveStepsEnum");
    }
    public void MoveSteps()
    {
        for(int i=0;i<5;i++)
        {
            transform.position = pathsParent.commonPathPoints[i].transform.position;
        }
    }
    IEnumerator MoveStepsEnum()
    {
        yield return new WaitForSeconds(0.25f);
        if (canMove)
        {
            for (int i = 0; i <7; i++)
            {
               transform.position=pathsParent.commonPathPoints[i].transform.position;
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}
