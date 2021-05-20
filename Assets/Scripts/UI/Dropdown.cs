using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dropdown : MonoBehaviour
{
    [SerializeField] Transform startingPos;
    [SerializeField] Transform offScreenPos;
    [SerializeField] Button[] ButtonList;

    bool isCategory = true;

    public void ResetAllPosition()
    {
        for (int i = 0; i < ButtonList.Length; i++)
        {
            ButtonList[i].transform.DOMove(offScreenPos.transform.position, .1f * i, true);
        }
    }

    public void buttonReset()
    {
        if(isCategory == false)
        {
            for (int i = 0; i < ButtonList.Length; i++)
            {
                ButtonList[i].transform.DOMove(new Vector3(startingPos.position.x, startingPos.position.y + (-60 * i), startingPos.position.z), .1f * i, true);
            }
        }
    }

    public void InputChange(int val)
    {
        if(val == 0)
        {
            isCategory = true; 
        }
        if (val == 1)
        {
            for(int i = 0; i < ButtonList.Length; i++)
            {
                ButtonList[i].transform.DOMove(new Vector3(startingPos.position.x, startingPos.position.y + (-60 * i), startingPos.position.z), .1f*i, true);
            }
            isCategory = false;
        }
        if (val == 2)
        {
            //input what you want to do
            isCategory = false;
        }
        if (val == 3)
        {
            //input what you want to do
            isCategory = false;
        }
        if (val == 4)
        {
            //input what you want to do
            isCategory = false;
        }
        if (val == 5)
        {
            //input what you want to do
            isCategory = false;
        }
        if (val == 6)
        {
            //input what you want to do
            isCategory = false;
        }


    }
}
