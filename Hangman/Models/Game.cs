using System;
using System.Collections.Generic;


namespace Game.Models
{
  public class GameClass
  {
    private static List<GameClass> _instances = new List<GameClass>{};
    public List<Letter> Letters {get; set;}
    public int id {get; set;}
    public int FailsRemaining {get; set;}

    public GameClass()
    {
      _instances.Add(this);
      id = _instances.Count;
      Letters = new List<Letter>{};
      FailsRemaining = 6;
      this.AssignRandomWord();
    }

    public static List<GameClass> GetAll()
    {
      return _instances;
    }

    public void Add(char letter)
    {
      Letters.Add(new Letter(letter));
    }

    public static GameClass Find(int id)
    {
      return _instances[id - 1];
    } 

    public void AssignRandomWord()
    {
      List<string> words = new List<string>{"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"};
      Random rand = new Random();
      int index = rand.Next(0,10);
      string randWord = words[index];
      foreach (char letter in randWord)
      {
        this.Add(letter);
      }
    }
  
  }
}