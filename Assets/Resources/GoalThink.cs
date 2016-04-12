using UnityEngine;
using System.Collections;

public class GoalThink : MonoBehaviour 
{


	// Use this for initialization
	void Start () 
	{
		renderer.material.shader = Shader.Find ("Specular");
		// Set red specular highlights
		renderer.material.SetColor ("_Color", Color.yellow);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision collision) 
	{
	}
}
