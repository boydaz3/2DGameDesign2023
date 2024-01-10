using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    private bool isPoweredOn = false;
    public Sprite poweredOnSprite;
    public Sprite poweredOffSprite;
    public bool isInPuzzleList = false;

    public float[] correctAngles;
    public void PowerOn()
    {
        isPoweredOn = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = poweredOnSprite;
    }
    public void PowerOff()
    {
        Debug.Log("a");
        isPoweredOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = poweredOffSprite;
    }
    public void OnMouseDown()
    {
        Puzzle puzzle = gameObject.transform.parent.gameObject.GetComponent<Puzzle>();
        gameObject.transform.Rotate(new Vector3(0, 0, 90f));
        Debug.Log(gameObject.transform.rotation.z);
        if (isInPuzzleList)
        {
            if (correctAngles.Length != 0)
            {
                foreach (float correctAngle in correctAngles)
                {
                    if (Mathf.Abs(gameObject.transform.rotation.z) == Mathf.Abs(correctAngle))
                    {
                        
                        for (int i = 0; i < puzzle.tiles.Count; i++)
                        {
                            if (puzzle.tiles[i] == this)
                            {
                                
                                if (i != 0)
                                {
                                    if (puzzle.tiles[i - 1].GetIsPoweredOn())
                                    {
                                        PowerOn();
                                    }
                                    else
                                    {
                                        PowerOff();
                                    }
                                }
                                else
                                {
                                    PowerOn();
                                }

                            }
                        }
                        
                    }
                    else
                    {
                        PowerOff();
                    }
                }
            }
        }
        foreach (PuzzleTile puzzleTile in puzzle.tiles)
        {
            puzzleTile.OnMouseDown();
        }
        
        puzzle.Check();
        
    }

    public bool GetIsPoweredOn()
    {
        return isPoweredOn;
    }
}
