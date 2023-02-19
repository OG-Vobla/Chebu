using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketScript : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] private GameObject Points;
	[SerializeField] private GameObject Score;
	private void Start()
	{
		
		Score.GetComponent<Text>().text = PlayerPrefs.GetInt("score").ToString();
	}
	private void Update()
	{
		if (int.Parse(Score.GetComponent<Text>().text) < int.Parse(Points.GetComponent<Text>().text))
		{
			Score.GetComponent<Text>().text = Points.GetComponent<Text>().text;
			PlayerPrefs.SetInt("score", int.Parse(Score.GetComponent<Text>().text));
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
		GetComponent<AudioSource>().Play();
		Points.GetComponent<Text>().text = (int.Parse(Points.GetComponent<Text>().text) + 1).ToString();
	}
}
