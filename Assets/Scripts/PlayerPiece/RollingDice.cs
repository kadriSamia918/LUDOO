using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int numberGot;
    [SerializeField] SpriteRenderer numberedSpHoldere;
    [SerializeField] Sprite[] numberedSprites;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            numberGot=Random.Range(0, 6);
            numberedSpHoldere.sprite = numberedSprites[numberGot];
            numberGot +=1;
        }
    }
}
