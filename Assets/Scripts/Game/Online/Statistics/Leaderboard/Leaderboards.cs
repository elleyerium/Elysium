using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Game.Online.Connector;
using Game.Online.Connector.Auth;

namespace Game.Online.Statistics.Leaderboard
{
    public class Leaderboards : MonoBehaviour
    {
        private List<ScoresListing> Listing = new List<ScoresListing>();
        private string allData,username,score;
        private bool ScoreFormed;
        public GameObject LoadScreen, playerPrefab;
        public Transform parent;
        private Task RequestTast;
        [SerializeField] private Text _attention;

        public void CheckStatus()
        {
            Debug.Log("simple");

            if (!Login.Logged && !ConnectMasterServer.IsConnected)
            {
                _attention.text = "You should be logged in!";
                Debug.Log("if");
            }
            else
            {
                _attention.gameObject.SetActive(false);
                Debug.Log("else if");
                RequestLeaderBoard();
            }
        }

        void RequestLeaderBoard()
        {
            //LoadScreen.SetActive(true);
            try
            {
                ConnectMasterServer connector = new ConnectMasterServer();
                    parent.transform.position = new Vector3(parent.transform.position.x, 0, 0);
                    allData = connector.Request(TypeOfTags.GetLeaderboardsRequest.ToString(),null);
                    Debug.Log(allData);
                    string[] clearArray = allData.Split('|');

                for (int i = 0; i < clearArray.Length; i++)
                {
                    string clearString = clearArray[i]; // Get the i element from string 6 times
                    string[] arrayDat = clearString.Split(',');
                    username = arrayDat[0];
                    score = arrayDat[1];
                    Listing.Add(new ScoresListing(i,username,Convert.ToInt32(score)));
                    ScoresListing listing = Listing[i];
                    SetScorePrefab(listing);
                    LoadScreen.SetActive(false);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex + " ex here!");
            }
        }

        void SetScorePrefab(ScoresListing listing)
        {
            GameObject scoreData = Instantiate(playerPrefab);
            scoreData.GetComponent<ScoreSerialize>().SetScore($"#{listing.id + 1}", listing.Username, listing.Score.ToString());
            Debug.Log($"{listing.id + 1} {listing.Username} {listing.Score}");
            scoreData.transform.SetParent(parent.transform);
            ScoreFormed = true;
        }
    }
}
