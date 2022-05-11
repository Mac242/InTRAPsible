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

        public List<TMP_Text>  _gameScores, _gameNames;

        private float _highscoreToSet, _tempScore,  _highScoreSpot; 
        private string _tempName;
        private string _scoreList, _scoreNameList;

        private string _defaultName = "ANNAMO";
        private float _defaultScores = 5000f;

        [SerializeField] public TMP_Text _submittedName;

        private void Start()
        {
            LoadCheckIfNoScores();
            SetHighScore();
            _defaultScores = 5000f;
            _scores[0] = 73f;
            _scores[1] = _defaultScores;
            _scores[2] = _defaultScores;
            _scores[3] = _defaultScores;
            _scores[4] = _defaultScores;
            _scores[5] = _defaultScores;
            _scores[6] = _defaultScores;
            _scores[7] = _defaultScores;
            _scores[8] = _defaultScores;
            _scores[9] = _defaultScores;
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
                    PlayerPrefs.SetString(_scoreNameList, _scoreNames[i]);
                }
            }
        }

        private void LoadScores()
        {
            _scores.Clear();
            _scoreNames.Clear();
            
            _scores.Add(PlayerPrefs.GetFloat(_scoreList));
            _scoreNames.Add(PlayerPrefs.GetString(_scoreNameList));
            
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
                    PlayerPrefs.SetString(_scoreNameList, _defaultName);
                }
            }
        }

       public void checkScore()
        {
            LoadScores();
            _highscoreToSet = 5000f;

            for (int i = 0; i < _scores.Count; i++)
            {
                if (Player_CTRL.overallTime < _scores[i])
                {
                    _highscoreToSet = i;
                    i = 10;
                }
            }
        }
       

        public void HighScoreToScore()
        {
            checkScore();
            
            if (Player_CTRL.overallTime < _scores[0])
            {
                _scores[0] = Player_CTRL.overallTime;
                _scoreNames[0] = _submittedName.text;
                _gameNames[0].text = _scoreNames[0];
                _scores[0] = (float) Math.Round(_scores[0], 2);
                _gameScores[0].text = _scores[0].ToString();
                PlayerPrefs.SetFloat(_scoreList, _scores[0]);
                PlayerPrefs.SetString(_scoreNameList, _scoreNames[0]);
            }
            
            else if (Player_CTRL.overallTime <= _scores[1] && Player_CTRL.overallTime > _scores[0])
            {
                _scores[1] = Player_CTRL.overallTime;
                _scoreNames[1] = _submittedName.text;
                _gameNames[1].text = _scoreNames[1];
                _scores[1] = (float) Math.Round(_scores[1], 2);
                _gameScores[1].text = _scores[1].ToString();
                PlayerPrefs.SetFloat(_scoreList, _scores[1]);
                PlayerPrefs.SetString(_scoreNameList, _scoreNames[1]);
            }
            
            else if (_highscoreToSet <= _scores[2] && _highscoreToSet > _scores[1])
            {
                _scores[2] = Player_CTRL.overallTime;
                _scoreNames[2] = _submittedName.text;
                _gameNames[2].text = _scoreNames[2];
                _scores[2] = (float) Math.Round(_scores[2], 2);
                _gameScores[20].text = _scores[2].ToString();
                PlayerPrefs.SetFloat(_scoreList, _scores[2]);
                PlayerPrefs.SetString(_scoreNameList, _scoreNames[2]);
            }
            else if (_highscoreToSet <= _scores[3] && _highscoreToSet > _scores[2])
            {
                _scores[3] = Player_CTRL.overallTime;
                _scoreNames[3] = _submittedName.text;
                _gameNames[3].text = _scoreNames[3];
                _scores[3] = (float) Math.Round(_scores[3], 2);
                _gameScores[3].text = _scores[3].ToString();
                PlayerPrefs.SetFloat(_scoreList, _scores[3]);
                PlayerPrefs.SetString(_scoreNameList, _scoreNames[3]);
            }
            
            else if (_highscoreToSet <= _scores[4] && _highscoreToSet > _scores[3])
            {
                _scores[4] = Player_CTRL.overallTime;
                _scoreNames[4] = _submittedName.text;
            }
            
            else if (_highscoreToSet <= _scores[5] && _highscoreToSet > _scores[4])
            {
                _scores[5] = Player_CTRL.overallTime;
                _scoreNames[5] = _submittedName.text;
            }
            
            else if (_highscoreToSet <= _scores[6] && _highscoreToSet > _scores[5])
            {
                _scores[6] = Player_CTRL.overallTime;
                _scoreNames[6] = _submittedName.text;
            }
            
            else if (_highscoreToSet <= _scores[7] && _highscoreToSet > _scores[6])
            {
                _scores[7] = Player_CTRL.overallTime;
                _scoreNames[7] = _submittedName.text;
            }
            
            else if (_highscoreToSet <= _scores[8] && _highscoreToSet > _scores[7])
            {
                _scores[8] = Player_CTRL.overallTime;
                _scoreNames[8] = _submittedName.text;
            }
            
            else if (_highscoreToSet <= _scores[9] && _highscoreToSet > _scores[8])
            {
                _scores[9] = Player_CTRL.overallTime;
                _scoreNames[9] = _submittedName.text;
            }

        }

    }
