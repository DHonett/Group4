using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class StopWatch : MonoBehaviour
{
    public float timePassed;
    public Text textBox;
	public GameObject start;
	public GameObject stop;

    public string startTimestamp, endTimestamp;

    public bool isTimerActive = false;

    DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://group4seizureapp.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        textBox.text = timePassed.ToString("F2");
        pressTimerButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerActive)
        {
            timePassed += Time.deltaTime; //timer keeps counting
            textBox.text = timePassed.ToString("F2"); //time converted to string
        }
    }

    public void pressTimerButton()
    {
        isTimerActive = !isTimerActive; //change the active state of the button

        if (isTimerActive)
        {
            timePassed = 0.0f;
            textBox.text = "0.00";
            startTimestamp = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); //create the time stamp when timer starts
			stop.SetActive(true);
			start.SetActive(false);
		}
        else if (!isTimerActive)
        {
            endTimestamp = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); //create the time stamp when timer stops
            
			stop.SetActive(false);
			start.SetActive(true);
            //REMOVE THIS - DEBUGGING PURPOSES ONLY
            print("\nStart: " + startTimestamp + "\tSTOP: " + endTimestamp + "\t" + "DURATION: " + timePassed.ToString("F2") + "\n\n");

            if (MainController.loggedIn)
            {
                reference.Child("Sprint2Demo").Child("S_History").Child("Duration: " + startTimestamp).SetValueAsync(timePassed.ToString("F2") + " Sent by: " + MainController.name);
            }
        }
    }
}
