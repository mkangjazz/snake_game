using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int _current_level = 1;
    public int current_level {
        get => _current_level;
        set => _current_level = value;
    }

    private interface ILevel
    {
        int id 
        { 
            get; set; 
        }
        float growWaitTime { get; set; }
        int maxSnakeLength { get; set; }
    }
    public class Level : ILevel {
        public Level(int level)
        {
            id = level;
            growWaitTime = GetCalculatedWaitTime(level);
            maxSnakeLength = level * 4;
        }
        private float GetCalculatedWaitTime(int n)
        {
            float retVal = (float)1 / ((float)n + 7f);

            Debug.Log($"GetCalculatedWaitTime: {retVal}");
            return retVal;
        }

        private int _id;
        public int id
        {
            get => _id;
            set => _id = value;
        }

        private float _speed;
        public float growWaitTime
        {
            get => _speed;
            set => _speed = value;
        }

        private int _length;
        public int maxSnakeLength {
            get => _length;
            set => _length = value;
        }
    }

    private void Start()
    {
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
    }

    public Level GetCurrentLevelInfo()
    {
        return new Level(current_level);
    }
}
