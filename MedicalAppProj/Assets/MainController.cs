using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
	public static bool loggedIn = false;
	public static string name = null;
	public static string position = null;
	static bool test = false;
	public static bool init = false;

    //added by dylan
    public static string phone = "911";

    // Start is called before the first frame update
    void Start()
    {
		if (test == false) {
        DontDestroyOnLoad(this.gameObject);
		test = true;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void logout () {
		loggedIn = false;
		name = null;
		position = null;
		print("logged out");

	}
}
