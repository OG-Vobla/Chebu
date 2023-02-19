using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseZoneScript : MonoBehaviour
{
	private int Lives= 3;
	[SerializeField] private GameObject Points;
	[SerializeField] private GameObject LoseWin;
	[SerializeField] private GameObject PauseWin;
	[SerializeField] private GameObject LivesCal;
	[SerializeField] private GameObject Live;
	[SerializeField] private GameObject Spawner1;
	[SerializeField] private GameObject Spawner2;
	[SerializeField] private GameObject Spawner3;
	[SerializeField] private GameObject Spawner4;
	[SerializeField] private GameObject Orange;
	[SerializeField] private GameObject Camera;
	private List<GameObject> Spawner1Oranges;
	private List<GameObject> Spawner2Oranges;
	private List<GameObject> Spawner3Oranges;
	private List<GameObject> Spawner4Oranges;

	static public float time = 0f;
	static public bool isGame = true;
	bool isPaused = false;
	// Start is called before the first frame update
	private void FixedUpdate()
	{
		if (isGame)
		{
			time += Time.deltaTime;
		}
		
	}
	private void Start()
	{


		StartCoroutine(SpawnOrange());
	}
	private void Update()
	{
		if ((Input.GetKeyDown(KeyCode.Space) || PlayerControl.Key == "Space") && isGame )
		{

			PlayerControl.Key = "";
			if (isPaused)
			{
				Camera.GetComponent<AudioSource>().Play();
			}
			else
			{
				Camera.GetComponent<AudioSource>().Pause();
			}
			isPaused= !isPaused;
		}
		if ((Input.GetKeyDown(KeyCode.Space) || PlayerControl.Key == "Space") && Lives == 0)
		{
			PlayerControl.Key = "";
			Points.GetComponent<Text>().text = "0";
			Instantiate(Live, LivesCal.transform);
			Instantiate(Live, LivesCal.transform);
			Instantiate(Live, LivesCal.transform);
			LoseWin.gameObject.SetActive(false);
			Lives = 3;
			time = 0f;
			isGame = true;
			StartCoroutine(SpawnOrange());
		}
		if (Input.GetKeyDown(KeyCode.Escape) || PlayerControl.Key == "Escape")
		{
			PlayerControl.Key = "";
			if (isGame)
			{
				isGame= false;
				PauseWin.gameObject.SetActive(true);
				Freeze();

			}
			else
			{
				isGame = true;
				PauseWin.gameObject.SetActive(false);
				UnFreeze();
			}
		}
		}
	public void Freeze()
	{
		Time.timeScale = 0f;
		
	}
	public void UnFreeze()
	{
		Time.timeScale = 1f;
	}
	private IEnumerator SpawnOrange()
	{
		while (isGame)
		{
			if (time < 20)
			{
				Spawn();
			}
			else if (time < 40 && time > 20)
			{
				Spawn();
				Spawn();
			}
			else if (time < 60 && time > 40)
			{
				Spawn();
				Spawn();
				Spawn();
			}
			yield return new WaitForSeconds(1);
		}

	}
	private void Spawn()
	{
		int val = Random.Range(0, 5);
		if (val == 1)
		{
			Instantiate(Orange, Spawner1.transform);
		}
		else if (val == 2)
		{
			Instantiate(Orange, Spawner2.transform);
		}
		else if (val == 3)
		{
			Instantiate(Orange, Spawner3.transform);
		}
		else if (val == 4)
		{
			Instantiate(Orange, Spawner4.transform);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		GetComponent<AudioSource>().Play();
		Destroy(collision.gameObject);
		if (Lives == 0)
		{
			return;
		}
		Lives--;
		Destroy(LivesCal.transform.GetChild(0).gameObject);
		if (Lives == 0)
		{
			for (int i = 0; i < Spawner1.transform.childCount; i++)
			{
				Destroy(Spawner1.transform.GetChild(i).gameObject);
			}
			for (int i = 0; i < Spawner2.transform.childCount; i++)
			{
				Destroy(Spawner2.transform.GetChild(i).gameObject);
			}
			for (int i = 0; i < Spawner3.transform.childCount; i++)
			{
				Destroy(Spawner3.transform.GetChild(i).gameObject);
			}
			for (int i = 0; i < Spawner4.transform.childCount; i++)
			{
				Destroy(Spawner4.transform.GetChild(i).gameObject);
			}
			Points.GetComponent<Text>().text = "0";
			LoseWin.gameObject.SetActive(true);
			isGame = false;
		}
	}
}
