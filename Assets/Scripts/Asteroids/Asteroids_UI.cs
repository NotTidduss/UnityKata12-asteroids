using UnityEngine;
using UnityEngine.UI;

public class Asteroids_UI : MonoBehaviour
{
    [Header ("Master")]
    [SerializeField] private Asteroids_Master master;

    [Header ("Menu")]
    [SerializeField] private GameObject resultMenu;

    [Header ("Text")]
    [SerializeField] private Text textNewHighScoreInfo;
    [SerializeField] private Text textScoreValue;
    [SerializeField] private Text textHighScoreValue;

    public void initialize() => resultMenu.SetActive(false);
    public void terminate() => resultMenu.SetActive(true);

    public void buttonPlayAgain() => master.sys.loadInitScene();
}
