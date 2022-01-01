using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class CubeController : MonoBehaviour
{
    public int index;
    public List<GameObject> cubes = new List<GameObject>();
    public bool wontime;
    [SerializeField] private GameObject trails;
   public int count=0;
   public int diamond;
   [SerializeField] private TMP_Text _tmPro;
   [SerializeField] private GameObject UIdiamond;
   public GameObject canvas;
  
    private void FixedUpdate()
    {
        
      
         
            if (wontime)
            {
                this.gameObject.transform.position = new Vector3(transform.position.x,  index+count, transform.position.z);
                trails.SetActive(false);
                UIdiamond.SetActive(true);
                _tmPro.text = diamond.ToString();

            }
            else
            {
                this.gameObject.transform.position = new Vector3(transform.position.x,index, transform.position.z);
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
                if (index==0)
                {
                    gameObject.GetComponent<CharacterMovement>().enabled = false;
                    LevelSystem.Instance.DidYouReturnPanel = true;
                    canvas.SetActive(false);
                    trails.SetActive(false);
                }
                cubes[index-1].transform.parent = null;
                cubes.RemoveAt(index-1);

                index--;
              
                other.gameObject.GetComponent<obstacle>().working = false;
            }
        }
        if (other.gameObject.CompareTag("won"))
        {
             
            if (other.gameObject.GetComponent<obstacle>().working)
            {
                if (index==0)
                {
                    gameObject.GetComponent<CharacterMovement>().enabled = false;
                    LevelSystem.Instance.DidYouReturnPanel = true;
                    canvas.SetActive(false);
                    
                }
                count++;
                index--;
                cubes[index].transform.parent = null;
                cubes.RemoveAt(index);
              
                wontime = true;
               
                other.gameObject.GetComponent<obstacle>().working = false;
            }
        }
        if (other.gameObject.CompareTag("collect"))
        {
            if (other.gameObject.GetComponent<obstacle>().working)
            {
                obstacle temp = other.GetComponent<obstacle>();
                temp.gems = true;
              
               diamond++;
               temp.working = false;
            }
        }

        if (other.gameObject.CompareTag("end"))
        {
            gameObject.GetComponent<CharacterMovement>().enabled = false;
            LevelSystem.Instance.DidYouNextLevelPanel = true;
            canvas.SetActive(false);
        }
    }

}
