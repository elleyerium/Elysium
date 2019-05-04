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
        private bool IsLoading = true;
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
                    RequestLeaderBoard();
                }
            yield return new WaitForSeconds(2);
        }

        void RequestLeaderBoard()
        {
            LoadScreen.SetActive(true);
            try
            {
                    parent.transform.position = new Vector3(parent.transform.position.x, -1400, 0);
                    allData = ConnectMasterServer.Request(TypeOfTags.GetLeaderboardsRequest.ToString(),null).ToString();
                    Debug.Log(allData);
                    if(allData != null)
                        IsLoading = false;     
                     Debug.Log(allData + " " + IsLoading);
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
                    IsLoading = false;
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
            GameObject ScoreData = Instantiate(playerPrefab);
            ScoreData.GetComponent<ScoreSerialize>().SetScore($"#{listing.id + 1}", listing.Username, listing.Score.ToString());
            Debug.Log($"{listing.id + 1} {listing.Username} {listing.Score}");
            ScoreData.transform.SetParent(parent.transform);
        }
    }
