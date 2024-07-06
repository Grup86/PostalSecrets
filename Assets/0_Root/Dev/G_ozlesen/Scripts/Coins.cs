using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Rigidbody2D RB;
    public bool isTrigger;
    public void Force(Vector3 pos)
    {
        SetIsTrigger(true);
        RB.AddForce(pos*.6f,ForceMode2D.Impulse);
    }
    public void SetIsTrigger(bool state)
    {
        isTrigger = state;
    }
}
