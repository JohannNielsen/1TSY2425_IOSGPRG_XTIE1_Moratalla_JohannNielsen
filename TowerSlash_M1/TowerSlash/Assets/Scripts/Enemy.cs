using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public _ArrowDirection thisEnemyDirection;
    public Sprite[] enemySprites;
    public Sprite[] reverseSprite;
    public enemyType thisEnemyType;

    private bool isChangingSprite = true;
    private float timeElapsed = 0f;
    private float spriteChangeInterval = 0.2f;
    private void Awake()
    {
        int randomizeEnemyType = Random.Range(0, 3);
        thisEnemyType = (enemyType)randomizeEnemyType;

        int randomizedRange = Random.Range(0, 4);
        thisEnemyDirection = (_ArrowDirection)randomizedRange;

        if (thisEnemyType == enemyType.green)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemySprites[randomizedRange];
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f);
        }
        else if (thisEnemyType == enemyType.red)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = reverseSprite[randomizedRange];
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = reverseSprite[randomizedRange];
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 0.0f);
        }
    }
    private void Update()
    {
        if (thisEnemyType == enemyType.yellow)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= spriteChangeInterval)
            {
                int randomizedRange = Random.Range(0, 4);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = reverseSprite[randomizedRange];
                timeElapsed = 0f;
            }
        }
    }
    public void StopChangeSprite()
    {
        isChangingSprite = false;
        int randomizeEnemyType = Random.Range(0, 2);
        thisEnemyType = (enemyType)randomizeEnemyType;

        int randomizedRange = Random.Range(0, 4);
        thisEnemyDirection = (_ArrowDirection)randomizedRange;

        if (thisEnemyType == enemyType.green)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemySprites[randomizedRange];
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f);
        }
        else if (thisEnemyType == enemyType.red)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = reverseSprite[randomizedRange];
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
        }
    }
}
