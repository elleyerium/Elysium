using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


public class Leaderboards : MonoBehaviour
    {
        private List<ScoresListing> Listing = new List<ScoresListing>();
        private string allData,username,score;
        private bool ScoreFormed;
        public GameObject LoadScreen, playerPrefab;
        public Transform parent;
        private Task RequestTast;

        void Start()
        {           
            StartCoroutine("Updater");
        }

        IEnumerator Updater()
        {
            if (!ConnectMasterServer.IsConnected)
            {
                ConnectMasterServer.Connect();
                yield return new WaitForSeconds(5);
            }

            if (ConnectMasterServer.IsConnected && !ScoreFormed)
            {
                RequestLeaderBoard();
                StopCoroutine(Updater());
            }
        }

        void RequestLeaderBoard()
        {
            LoadScreen.SetActive(true);
            try
            {
                    parent.transform.position = new Vector3(parent.transform.position.x, 0, 0);
                    allData = ConnectMasterServer.Request(TypeOfTags.GetLeaderboardsRequest.ToString(),null);
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
