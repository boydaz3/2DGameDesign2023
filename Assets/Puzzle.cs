using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public List<PuzzleTile> tiles = new List<PuzzleTile>();

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            tiles.Add(gameObject.transform.GetChild(i).GetComponent<PuzzleTile>());
        }
    }
}
