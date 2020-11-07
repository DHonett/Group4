using Firebase;
using Firebase.Analytics;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

using TMPro;

public class FirebaseInit2 : MonoBehaviour
{



    public UnityEvent OnFirebaseInitialized = new UnityEvent();

    // Start is called before the first frame update
    async void Start()
    {
		
		if (MainController.init == false) {

			
			
			var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync(); 
			if (dependencyStatus == DependencyStatus.Available)
			{
				OnFirebaseInitialized.Invoke();

			}

		   

			//below this comment is additional code, added to the original
			await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(continuationAction: task =>
			{
				FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
			});
			
			MainController.init = true;
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
