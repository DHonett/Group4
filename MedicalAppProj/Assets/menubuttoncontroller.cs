using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubuttoncontroller : MonoBehaviour
{
	private GameObject MController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void logoutbutton()
	{
		MController = GameObject.Find("MainController");
		MController.gameObject.GetComponent<MainController>().logout();
		
	}

    public void updatebutton()
    {
        //SceneManager.LoadScene("Profile update");
        if(MainController.position == "Patient")
        {
            SceneManager.LoadScene("patientupdate");
        }
        else if (MainController.position == "Caretaker" || MainController.position == "Doctor")
        {
            SceneManager.LoadScene("personnelupdate");
        }
    }

}
