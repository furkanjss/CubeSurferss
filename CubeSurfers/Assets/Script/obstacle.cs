using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public bool working=true;
    public bool gems;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Update()
    {
        if (gems)
        {
            StartCoroutine(creater());

        }
    }

    IEnumerator creater()
    {
        ParticleSystem part= Instantiate(_particleSystem,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        part.Stop();
        this.gameObject.SetActive(false);

    }
    
}
