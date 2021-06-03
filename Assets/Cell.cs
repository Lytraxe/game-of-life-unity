using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isAlive = false;
    public int neighbours = 0;

    public void SetAlive(bool alive)
    {
        isAlive = alive;
        if(alive)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (!isAlive)
        {
            SetAlive(true);
        }
        else
            SetAlive(false);
    }
}
