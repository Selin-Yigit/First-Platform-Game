using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// leveller ile ilgilenebilmek için.

public class NextLevel : MonoBehaviour
{
      private Scene _scene;
      //[SerializeField] private int sceneIndex;

    private void Awake(){
        _scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            //Engele çarpıldığında level yeniden başlayacak.

            // index ile bir sonraki sahne çağrılır.(Yöntem1)
            SceneManager.LoadScene(_scene.buildIndex+1);

            // SerializeField ile NextLevel Scriptinde elle doldurulan SceneIndex'in kullanılması(Yönetm2)
            //SceneManager.LoadScene(sceneIndex);

        }
    }

    public void StartLevel(){
        SceneManager.LoadScene(_scene.buildIndex+1);
    }

}
