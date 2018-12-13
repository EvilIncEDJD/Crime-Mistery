using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherMoveAi : MonoBehaviour {

	 Animator animator;
	 Coroutine myCoroutine;
	public enum AiState { TIRED, THIRSTY, BORED, ANGRY, LONELY};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public bool TheOldSwitcheroo(AiState state)
	{
		switch (state)
		{
			case AiState.TIRED:
			break;
			case AiState.THIRSTY:
			break;
			case AiState.BORED:
			break;
			case AiState.ANGRY:
			break;
			case AiState.LONELY:
			break;

		}
	}
}
