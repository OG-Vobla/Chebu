using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject LeftUpPos;
	[SerializeField] private GameObject LeftDownPos;
	[SerializeField] private GameObject RightUpPos;
	[SerializeField] private GameObject RightDownPos;
	public static string Key;
	private bool PlayerRight = false;
	// Start is called before the first frame update
	void Start()
    {

		
	}

	// Update is called once per frame
	public void PressKey(string key)
	{
		Key = key;
	}
	void Update()
    {
		if (LoseZoneScript.isGame)
		{
			if (Input.GetKeyDown(KeyCode.A) || Key == "A")
			{
				if (PlayerRight)
				{
					Flip();
				}
				transform.position = LeftDownPos.transform.position;
			}
			else if (Input.GetKeyDown(KeyCode.Q) || Key == "Q")
			{
				if (PlayerRight)
				{
					Flip();
				}
				transform.position = LeftUpPos.transform.position;
			}
			else if (Input.GetKeyDown(KeyCode.E) || Key == "E")
			{
				if (!PlayerRight)
				{
					Flip();
				}
				transform.position = RightUpPos.transform.position;
			}
			else if (Input.GetKeyDown(KeyCode.D) || Key == "D")
			{
				if (!PlayerRight)
				{
					Flip();
				}
				transform.position = RightDownPos.transform.position;
			}

		}

	}
	
	private void Flip()
	{

		PlayerRight = !PlayerRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
