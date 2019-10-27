using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class buttonScript : MonoBehaviour
{

	[Header("Exit")]
	public bool isExiting = false;
	public GameObject exitWindow;

	[Header("Gyro")]
	public bool must = false;
	public Text gyroText, gyroText2, gyroText3;
	public Text popularity;
	public int popint = 100;



	[Header("Vectors")]
	public Vector2 Leftvector = new Vector2(-200, 0);
	public Vector2 Cenvector = new Vector2(0, 0);
	public Vector2 Rightvector = new Vector2(200, 0);

	[Space(20)]
	public int curObj = 0, prevObj = 0;
	public float lerpFactor = 0.4f;
	public int count = 5;
	public GameObject[] arr = new GameObject[5];
	public GameObject topP, botP;




	void Start()
	{
		Input.gyro.enabled = true;
		

		/*
		arr[1].GetComponent<RectTransform>().right = Vector3.zero;
		arr[1].transform.position = arr[0].transform.position;
		arr[2].transform.position = arr[0].transform.position;
		arr[3].transform.position = arr[0].transform.position;

		arr[1].SetActive(false);
		arr[2].SetActive(false);
		arr[3].SetActive(false);
		*/
		arr[0].SetActive(true);
		for (int i = 1; i < count; i++)
		{
			arr[i].transform.position = arr[0].transform.position;
			arr[i].SetActive(false);
		}
		/*
		if (arr[0].activeSelf == true)
		{
			topP.SetActive(false);
			botP.SetActive(false);
		}
		*/
		topP.SetActive(!arr[0].activeSelf);
		botP.SetActive(!arr[0].activeSelf);
	}

	public void buttonAction(int num)
	{
		if (curObj != num)
		{
			prevObj = curObj;
			arr[prevObj].SetActive(false);
			curObj = num;
			arr[curObj].SetActive(true);
		}
		topP.SetActive(!arr[0].activeSelf);
		botP.SetActive(!arr[0].activeSelf);
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			exitWindow.SetActive(true);
		}
		gyroText.text = Input.gyro.rotationRate.magnitude.ToString();
		gyroText2.text = Input.gyro.rotationRate.y.ToString();
		//gyroText3.text = Input.gyro.gravity.z.ToString();
		popularity.text = popint.ToString() + "K";
		if (Random.Range(0, 100) > 89)
		{
			popint = popint + Random.Range(0, 4);
		}
		if (Input.gyro.rotationRate.magnitude > 2)
		{
			gyroText2.color = Color.red;
		}
		else
		{
			gyroText2.color = Color.black;
		}
	}

	public void ExitWindow(int num)
	{
		if (num == 0)
		{
			Application.Quit();
		}
		if (num == 1)
		{
			exitWindow.SetActive(false);
		}
	}
}
