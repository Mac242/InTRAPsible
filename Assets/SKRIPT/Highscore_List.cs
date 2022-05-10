using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Search;
using UnityEngine.SocialPlatforms.Impl;


public class Highscore_List : MonoBehaviour
    {
        public List<float> _scores = new List<float>();
        public List<string> _scoreNames = new List<string>();

        public List<TMP_Text> _mainMenuScores, _mainMenuNames, _gameScores, _gameNames;

        private float _highscoreToSet, _tempScore,  _highScoreSpot; 
        private string _tempName;
        private string _scoreList, _scoreNameList;

        private string _defaultName = "ANNAMO";
        private float _defaultScores = 5000f;

        [SerializeField] public TMP_Text _submittedName;

        private void Start()
        {
            SetGameScoreBoard();
            LoadCheckIfNoScores();
            SetHighScore();
        }

        public void SetHighScore()
        {
            for (int i = 0; i < _scores.Count; i++)
            {
                if (_highscoreToSet <= i)
                {
                    _tempName = _scoreNames[i];
                    _scoreNames[i] = _submittedName.text;
                    _submittedName.text = _tempName;

                    _tempScore = _scores[i];
                    _scores[i] = Player_CTRL.overallTime;
                    Player_CTRL.overallTime = _tempScore;
                    
                    _scoreList = "Score" + i;
                    _scoreNameList = "ScoreName" + i;
                
                    PlayerPrefs.SetFloat(_scoreList, _scores[i]);
                    PlayerPrefs.SetString(_scoreNameList, _scoreNames[i].ToUpper());
                }
            }
        }

        private void LoadScores()
        {
            _scores.Clear();
            _scoreNames.Clear();

            for (int i = 0; i < 10; i++)
            {
                _scoreList = "Score" + i;
                _scoreNameList = "ScoreName" + i;
                _scores.Add(PlayerPrefs.GetFloat(_scoreList));
                _scoreNames.Add(PlayerPrefs.GetString(_scoreNameList));
            }
        }

        public void LoadCheckIfNoScores()
        {
            if (_scores.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    _defaultScores = 5000f;
                    _scoreList = "Score" + i;
                    _scoreNameList = "ScoreName" + i;
                    PlayerPrefs.SetFloat(_scoreList, _defaultScores);
                    PlayerPrefs.SetString(_scoreNameList, _defaultName.ToUpper());
                }
            }
        }

       public float checkScore( float score)
        {
            LoadScores();
            _highscoreToSet = 5000f;

            for (int i = 0; i < _scores.Count; i++)
            {
                if (score < _scores[i])
                {
                    _highscoreToSet = i;
                    i = 10;
                }
            }

            return _highscoreToSet;
        }
       

        public void HighScoreToScore()
        {
            checkScore(Player_CTRL.overallTime);
            
            if (_tempScore < _scores[0])
            {
                _scores[0] = Player_CTRL.overallTime;
                _scoreNames[0] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[1] && Player_CTRL.overallTime > _scores[0])
            {
                _scores[1] = Player_CTRL.overallTime;
                _scoreNames[1] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[2] && Player_CTRL.overallTime > _scores[1])
            {
                _scores[2] = Player_CTRL.overallTime;
                _scoreNames[2] = _submittedName.text;
            }
            if (Player_CTRL.overallTime <= _scores[3] && Player_CTRL.overallTime > _scores[2])
            {
                _scores[3] = Player_CTRL.overallTime;
                _scoreNames[3] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[4] && Player_CTRL.overallTime > _scores[3])
            {
                _scores[4] = Player_CTRL.overallTime;
                _scoreNames[4] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[5] && Player_CTRL.overallTime > _scores[4])
            {
                _scores[5] = Player_CTRL.overallTime;
                _scoreNames[5] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[6] && Player_CTRL.overallTime > _scores[5])
            {
                _scores[6] = Player_CTRL.overallTime;
                _scoreNames[6] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[7] && Player_CTRL.overallTime > _scores[6])
            {
                _scores[7] = Player_CTRL.overallTime;
                _scoreNames[7] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[8] && Player_CTRL.overallTime > _scores[7])
            {
                _scores[8] = Player_CTRL.overallTime;
                _scoreNames[8] = _submittedName.text;
            }
            
            if (Player_CTRL.overallTime <= _scores[9] && Player_CTRL.overallTime > _scores[8])
            {
                _scores[9] = Player_CTRL.overallTime;
                _scoreNames[9] = _submittedName.text;
            }

        }
       
        public void SetGameScoreBoard()
        {
            LoadScores();
            int loop = 0;
            foreach (TMP_Text score in _gameScores)
            {
                score.text = _scores[loop].ToString();
                loop++;
            }
            
            loop = 0;
            foreach (TMP_Text name in _gameNames)
            {
                name.text = _scoreNames[loop];
                loop++;
            }

            loop = 0;

        }
        
    }
