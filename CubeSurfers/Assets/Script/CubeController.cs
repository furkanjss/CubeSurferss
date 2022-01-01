using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int index;
    public List<GameObject> cubes = new List<GameObject>();
    public bool wontime;
  

    private void FixedUpdate()
    {
      
         
            if (wontime)
            {
                this.gameObject.transform.position = new Vector3(transform.position.x, index+index/index*0.2f, transform.position.z);
            }
            else
            {
                this.gameObject.transform.position = new Vector3(transform.position.x, index, transform.position.z);
            }
     
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Canadd"))
        {
            if (other.gameObject.GetComponent<canCollect>().working)
            {

                canCollect temp = other.GetComponent<canCollect>();
                
              temp.parentChanger(this.gameObject);
               
                index++;
               
                other.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - index,
                    transform.position.z);
                cubes.Add(other.gameObject);
                temp.working = false;


            }
        }
        if (other.gameObject.CompareTag("obstacle"))
        {
            if (other.gameObject.GetComponent<obstacle>().working)
            {
              
                cubes[index-1].transform.parent = null;
                cubes.RemoveAt(index-1);

                index--;
              
                other.gameObject.GetComponent<obstacle>().working = false;
            }
        } if (other.gameObject.CompareTag("won"))
        {
            if (other.gameObject.GetComponent<obstacle>().working)
            {
                wontime = true;
                cubes[index-1].transform.parent = null;
                cubes.RemoveAt(index-1);

                index--;
              
                other.gameObject.GetComponent<obstacle>().working = false;
            }
        }
    }

  
}
