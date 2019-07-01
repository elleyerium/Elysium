using UnityEngine;
using UnityEngine.UI;
using Game.AI.Data;
using Game.AI.Initiate;
using Game.Difficult;
using Game.Graphics.Effects;
using Game.Player.Health;
using Game.Player.Scoring;
using Game.Player.Weapon;

namespace Game.SceneData.Actions
{
    public class RestartonDeath : MonoBehaviour
  {
    public GameObject deathScreen, player;
    [SerializeField] private Transform main;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _ReBorn;
    [SerializeField] private GameObject _exp, AnswerField, _msg;
    [SerializeField] Text CountOfKills, TotalScore, question, _answerField;
    private int _summ, _counter = 0;

    void Start() => Question();

    void SaveToDataBase() =>
        PlayerPrefs.SetFloat("TotalScore", (PlayerPrefs.GetFloat("TotalScore") + LocalScoringByDifficulty.Currently_score));
    void SendData()
    {
        var ScoreDatas = LocalScoringByDifficulty.Currently_score.ToString("F2");
        WWWForm Server = new WWWForm();
        Server.AddField("scores", ScoreDatas);
        Server.AddField("username", PlayerPrefs.GetString("username"));
        string url = "http://elysium.lh1.in/ScoreParse.php";
        WWW www = new WWW(url, Server);
    }
    void Update()
    {
        if (_counter >=1)
        {
            question.text = ("Have no more attempts!");
            AnswerField.SetActive(false);
        }

        CountOfKills.text = ("Destroyed bots : " + Spawnedbothp.Countofkilled);
        TotalScore.text = ("Total score : " + LocalScoringByDifficulty.Currently_score.ToString("F2"));
    }

    public void RestartGame()
    {
        Bots.botCounter = 0;
        Initiate.Fade("bots", Color.black, 4.5f);
        Time.timeScale = 1;
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;
    }

    public void Mainmenu()
    {
        SendData();
        SaveToDataBase();
        BotDifficult.abitharder = false;
        BotDifficult.noob = false;
        BotDifficult.impossible = false;
        Bots.botCounter = 0;
        Initiate.Fade("Main", Color.black, 2.5f);
        Time.timeScale = 1;
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;
        if (LocalScoringByDifficulty.Currently_score >= PlayerPrefs.GetFloat("Highest score"))
        {
            PlayerPrefs.SetFloat("Highest score", LocalScoringByDifficulty.Currently_score);
        }

    }

    void Question()
    {
        var first = UnityEngine.Random.Range(0, 512);
        var second = UnityEngine.Random.Range(0, 1024);
        var summ = first + second;
        question.text = ("Solve this : " + first + " + " + second);
        _summ = summ;
        Debug.Log(first + "," + second);
        Debug.Log("Summ :" + summ);

    }

    public void Respawn()
    {
        var answer = _answerField;
        if (answer.text == _summ.ToString())
        {
            _counter++;
            _exp.SetActive(true);
            _AudioSource.PlayOneShot(_ReBorn);
            HealthbarScript._respawner.SetActive(true);
            deathScreen.SetActive(false);
            HealthbarScript.health = 100;
            GameObject Error = Instantiate(_msg);
            Error.transform.SetParent(main, false);
            Destroy(Error,2.3f);
        }
        else
         Debug.Log("Wrong answer. Try again");
    }
  }
}
