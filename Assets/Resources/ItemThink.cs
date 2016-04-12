using UnityEngine;
using System.Collections;

public class ItemThink : MonoBehaviour 
{
	public bool carried = false; 
	public string param_weight = "light";

	
	// Use this for initialization
	void Start () 
	{
		renderer.material.shader = Shader.Find ("Specular");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(carried == true)
		{
			renderer.material.shader = Shader.Find ("Specular");
			renderer.material.SetColor ("_Color", Color.red);
		}

		else if(carried == false)
		{
			renderer.material.shader = Shader.Find ("Specular");
			if(param_weight == "light")
				renderer.material.SetColor ("_Color", new Color(1f,1f,1f,0.5f));
			else
				renderer.material.SetColor ("_Color", new Color(0.5f,0.5f,0.5f,1f));
		}

	}
}
