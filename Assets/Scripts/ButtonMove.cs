using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonMove : MonoBehaviour
{
    [SerializeField] Transform offScreenPos;

    public void ClickedPosition()
    {
        transform.DOMove(offScreenPos.transform.position, .1f, true);
    }
}
