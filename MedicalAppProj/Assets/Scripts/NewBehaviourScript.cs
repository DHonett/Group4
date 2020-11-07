using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EmergencyCallButton()
    {
        print("Emergency Call button has been pressed");
    }

    public void TimerButton()
    {
        print("Timer button has been pressed");
    }

    public void SceneChanger(){
        SceneManager.LoadScene("Login");

    }

    public void HomeScreenReturn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreateAccountSceneCange()
    {
        SceneManager.LoadScene("CreateAccount");
    }

}
