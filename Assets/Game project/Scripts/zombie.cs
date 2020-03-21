using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;


public class zombie : MonoBehaviour
{
    public float MoveSpeed;
    [Task]
   void ChangeSpeed ()
    {
        MoveSpeed = 5.0f;
    }

    [Task]
    void Stop()
    {
        MoveSpeed = 0;
    }
}
