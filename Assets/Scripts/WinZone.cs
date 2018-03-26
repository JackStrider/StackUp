using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinZone : MonoBehaviour {
    private bool FinishPlane = false;
       
    void Start()
    {
        FinishPlane = false;
    }

    private void Update()
    {
        if (FinishPlane == true)
        {
            SceneManager.LoadScene("Menu 3D", LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            FinishPlane = true;
        }
    }
}
