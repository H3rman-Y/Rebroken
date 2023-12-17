using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(()=> {
            SceneManager.LoadScene(int.Parse(this.name));
        });    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
