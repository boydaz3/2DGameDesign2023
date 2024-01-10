using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    private bool isPoweredOn = false;
    public Sprite poweredOnSprite;
    public Sprite poweredOffSprite;

    public float[] correctAngles;
    public void PowerOn()
    {
        isPoweredOn = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = poweredOnSprite;
    }
    public void PowerOff()
    {
        isPoweredOn = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = poweredOffSprite;
    }
    private void OnMouseDown()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 90f));
        if (correctAngles.Length != 0)
        {
            foreach (float correctAngle in correctAngles)
            {
                if (gameObject.transform.rotation.z == correctAngle)
                {
                    PowerOn();
                }
                else
                {
                    PowerOff();
                }
            }
        }
        gameObject.transform.parent.gameObject.GetComponent<Puzzle>().Check();
        
    }

    public bool GetIsPoweredOn()
    {
        return isPoweredOn;
    }
}
