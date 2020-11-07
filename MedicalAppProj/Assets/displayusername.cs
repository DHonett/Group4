using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class displayusername : MonoBehaviour
{
	public GameObject login;
	public TextMeshProUGUI name;
	public GameObject nameobj;
	public TextMeshProUGUI rolename;
	public GameObject roleobj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
                if (MainController.loggedIn == true){
			login.SetActive(false);
			nameobj.SetActive(true);
			name.text = MainController.name;
			roleobj.SetActive(true);
			rolename.text = MainController.position;
		}
		                if (MainController.loggedIn == false){
			login.SetActive(true);
			nameobj.SetActive(false);
			name.text = null;
			roleobj.SetActive(false);
			rolename.text = null;
		}
    }
}
