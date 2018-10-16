using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScript : MonoBehaviour {

    public enum State { BLUE, RED, EMPTY };

    public State[] cells;

    public GameObject redPrefab;

    public GameObject bluePrefab;

    public State turn;

    public int turnCount;

    public Text wonText;

    public GameObject[] Reference;

    private void Start()
    {
        cells = new State[9];

        for (int i = 0 ; i < cells.Length; i++)
        {
            cells[i] = State.EMPTY;
        }
        turnCount = 0;
        turn = State.RED;
    }


    private void Update()
    {
       if (whoWon() != State.EMPTY && Draw() == false)
        {
            wonText.text = whoWon().ToString() +" Won!!";
            SetThemInactive();
        }
        else if (whoWon() == State.EMPTY && Draw() == true)
        {
            wonText.text = "DRAW!";
            SetThemInactive();
        }
        else
        {
            wonText.text = turn.ToString();
        }
    }

    public void insert(GameObject GO,int index)
    {
        if (turn == State.BLUE)
        {
            cells[index] = State.BLUE;
            //index added to cells 
            Instantiate(bluePrefab, GO.transform.position, Quaternion.identity);
            turn = State.RED;

        }else {
            cells[index] = State.RED;
            //index added to cells 
            Instantiate(redPrefab, GO.transform.position, Quaternion.identity);
            turn = State.BLUE;
        }
        GO.SetActive(false);

    }

    public State whoWon()
    {
        if (cells[6] == cells[7] && cells[7] == cells[8])
            return cells[6];
        if (cells[3] == cells[4] && cells[4] == cells[5])
            return cells[3];
        if (cells[0] == cells[1] && cells[1] == cells[2])
            return cells[0];
        if (cells[0] == cells[3] && cells[3] == cells[6])
            return cells[0];
        if (cells[1] == cells[4] && cells[4] == cells[7])
            return cells[1];
        if (cells[2] == cells[5] && cells[5] == cells[8])
            return cells[2];
        if (cells[0] == cells[4] && cells[4] == cells[8])
            return cells[0];
        if (cells[2] == cells[4] && cells[4] == cells[6])
            return cells[2];
        return State.EMPTY;
    }

    bool Draw()
    {
        for (int i = 0; i < 8; i++)
        {
            if (cells[i] == State.EMPTY)
            {
                return false;
            }
        }   

        return true;
    }
    //in case of a win we set all the cells we didn't use inactive
   public void SetThemInactive()
    {
        for (int i = 0; i < 9; i++)
        {
            if (Reference[i].active)
                Reference[i].SetActive(false);
        }   

    }
}
