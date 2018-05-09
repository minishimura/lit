using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour{
	[SceneName]
	public string nextLevel;
    public GameObject[] animal;
    public GameObject selectedImage;

    Image image;
    Sprite[] sprite = new Sprite[5];

    void Awake(){
        for (int i = 0; i < animal.Length; i++){
            sprite[i] = Resources.Load<Sprite>(animal[i].name);
        }
    }

    void Start(){
        image = selectedImage.GetComponent<Image>();
        
	}


	void Update()
    {
        for (int i = 1; i <= animal.Length; ++i){
            if(Input.GetKeyDown(i.ToString())){
                image.sprite = sprite[i - 1];

            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(nextLevel);
        }
	}
}
