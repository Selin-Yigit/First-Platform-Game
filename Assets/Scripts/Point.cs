using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Point : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.CompareTag("Player")){
        Destroy(gameObject);
        
    }
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
