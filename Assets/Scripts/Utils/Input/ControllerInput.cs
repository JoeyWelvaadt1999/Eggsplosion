using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {
	[SerializeField]private int _controllerNumber;
	private string _controllerAxisX;
	private string _controllerJump;
	private string _controllerDash;

	private PlayerMovement _playerMovement;
	private PlayerJump _playerJump;

	private float x;

	// Use this for initialization
	void Start () {
//		PlayerInformation playerInfo = GetComponent<PlayerInformation> ();
		FindComponents();

//		_controllerNumber = playerInfo.PlayerNumber;

		_controllerAxisX = InputStrings._horizontal + _controllerNumber.ToString ();
		_controllerJump = InputStrings._jump + _controllerNumber.ToString ();
		_controllerDash = InputStrings._dash + _controllerNumber.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		
		x = Input.GetAxisRaw(_controllerAxisX);
	

		_playerMovement.Flip (x);

		if (Input.GetButtonDown(_controllerJump)) {
			_playerJump.Jump ();
		}

		if (Input.GetButtonDown (_controllerDash)) {
			_playerMovement.InitDash ();
		}

	
			_playerMovement.Move (x);	


	}

	public void FindComponents() {
		_playerJump = GetComponent<PlayerJump> ();
		_playerMovement = GetComponent<PlayerMovement> ();
	}
		
}
