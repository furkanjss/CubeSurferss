using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canCollect : MonoBehaviour
{
    public bool working=true;

    public void parentChanger(GameObject Player)
    {
        this.transform.parent = null;
        this.transform.parent = Player.transform;
     

    }
}
