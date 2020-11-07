using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menubuttonanim : MonoBehaviour
{
	public Animator animator;
	bool open = false;
	int test = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	public void pressed () {
		test = 0;
		
		if (open == false && test == 0)
		{
			animator.SetTrigger("open");
			open = true;
			test = 1;
			
		}
		if (open == true && test == 0) 
		{
			animator.SetTrigger("close");	
			open = false;
			test = 1;
			
		}
		
		
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

