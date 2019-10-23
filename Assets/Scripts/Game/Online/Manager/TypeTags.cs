using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

namespace Game.Online.Connector
{
	public enum TypeOfTags
	{
		RegistrationRequest = 0,
		LoginRequest = 1,
		SetScoreRequest = 2,
		GetScoreRequest = 3,
		GetLeaderboardsRequest = 4,
		GetClientID = 5
	}
}
