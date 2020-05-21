using System.Collections.Generic;

namespace Game.Models
{
  public class Letter
  {
    public char LetterOfWord {get;set;}
    public bool Visible {get;set;}
    public Letter(char letter)
    {
      LetterOfWord = letter;
      Visible = false;
    }
  }
}