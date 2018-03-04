using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoad : MonoBehaviour {
	public AudioClip buttonClick;
	AudioSource audioSource;
	public string levelLoad;
	public string optionsLoad;


	public void Start(){
		audioSource = GetComponent<AudioSource>();

	}

	public void Loadlevel()
	{
		audioSource.PlayOneShot (buttonClick, 0.7F);
		StartCoroutine(ButtonSound());
		SceneManager.LoadScene(levelLoad);
	}

	public void LoadOptions()
	{
		SceneManager.LoadScene(optionsLoad);
	}

	public void LoadlHome()
	{
		audioSource.PlayOneShot (buttonClick, 0.7F);
		StartCoroutine(ButtonSound());
		SceneManager.LoadScene("Menu");
	}

	public void LoadlExit()
	{
		audioSource.PlayOneShot (buttonClick, 0.7F);
		StartCoroutine(ButtonSound());
		Application.Quit ();
	}
		
	IEnumerator ButtonSound()
	{
		yield return new WaitForSeconds(1);
	}
}
