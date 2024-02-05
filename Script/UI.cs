using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelSet : MonoBehaviour
{
    public GameObject FirstPanel , SettingPanel;
    [SerializeField] Sprite MusicOn, MusicOff, SoundOn, SoundOff;
    [SerializeField] Button MusicBtn, SoundBtn;
    [SerializeField] AudioSource MusicSource, SoundSource;


    private void Start()
    {
        if (MusicComan.instance.IsMusic)
        {
            MusicBtn.GetComponent<Image>().sprite = MusicOn;
            MusicSource.mute = false;
        }
        else
        {
            MusicBtn.GetComponent<Image>().sprite = MusicOff;
            MusicSource.mute = true;
        }
        if (MusicComan.instance.IsSound)
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOn;
            SoundSource.mute = false;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOff;
            SoundSource.mute = true;
        }
    }
    public void GamePlay()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingPanelOpen()
    {
        SettingPanel.SetActive(true);
        //FirstPanel.SetActive(false);
    }
    public void SettingPanelClose()
    {
        FirstPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }
    public void MusicManagement()
    {
        if (MusicComan.instance.IsMusic)
        {

            MusicBtn.GetComponent<Image>().sprite = MusicOff;
            MusicComan.instance.IsMusic = false;
            MusicSource.mute = true;
        }
        else
        {
            MusicBtn.GetComponent<Image>().sprite = MusicOn;
            MusicComan.instance.IsMusic = true;
            MusicSource.mute = false;
        }
    }
    public void SoundManagement()
    {
        if (MusicComan.instance.IsSound)
        {

            SoundBtn.GetComponent<Image>().sprite = SoundOff;
            MusicComan.instance.IsSound = false;
            SoundSource.mute = true;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOn;
            MusicComan.instance.IsSound = true;
            SoundSource.mute = false;
        }
    }
}
