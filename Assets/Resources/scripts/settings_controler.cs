using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings_controler : MonoBehaviour
{
  public Slider musicSlider;
  public Button applySettingsButton;
  public AudioSource backgroundMusic;
  public float musicVolume;

  private void Awake()
  {
    applySettingsButton.onClick.AddListener(applySettingsButtonClicked);
    musicSlider.onValueChanged.AddListener(delegate {musicSliderChanged();});
  }
    // Start is called before the first frame update
    void Start()
    {
      musicVolume = musicSlider.value;
      backgroundMusic.volume = musicVolume;
    }

    void applySettingsButtonClicked()
    {
      Debug.Log(musicVolume);
      backgroundMusic.volume = musicVolume;
    }

    public void musicSliderChanged()
    {
      musicVolume = musicSlider.value;
      Debug.Log(musicVolume);
    }
}
