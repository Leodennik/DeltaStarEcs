using DeltaStar.Configuration;
using UnityEngine;


namespace DeltaStar.UnityComponents
{
    [RequireComponent(typeof(AudioSource))]
    public class UI : MonoBehaviour
    {
        private AudioSource _audioSource;
        public MusicConfiguration musicConfiguration;

        public ScreenView screenStart;
        public ScreenView screenChooseShip;
        public GameScreenView screenGame;
        public ScreenView screenPause;

        private bool _isPaused = false;
        
        private ScreenView[] _arrayScreens;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _arrayScreens = GetComponentsInChildren<ScreenView>(true);
            ToScreenMain();
            
        }
        
        public void ToScreenMain()
        {
            DisableAllScreens();
            screenStart.Show(true);

            Cursor.visible = true;
            
            PlayMusic(musicConfiguration.musicMainMenu);
        }
        
        public void ToScreenChooseShip()
        {
            DisableAllScreens();
            screenChooseShip.Show(true);
            
            Cursor.visible = true;
            PlayMusic(musicConfiguration.musicMainMenu);
        }

        public void ToScreenGame(int selectedShipIndex)
        {
            DisableAllScreens();
            screenGame.selectedShipIndex = selectedShipIndex;
            screenGame.Show(true);
            
            Cursor.visible = false;
            PlayMusic(musicConfiguration.musicGame);
        }

        private void PlayMusic(AudioClip music)
        {
            if (_audioSource.clip == music) return;
            
            _audioSource.Stop();
            _audioSource.clip = music;
            _audioSource.Play();
        }


        public void Exit()
        {
            Application.Quit();
        }

        private void DisableAllScreens()
        {
            foreach (ScreenView screen in _arrayScreens)
            {
                screen.Show(false);
            }
        }
    }
}
