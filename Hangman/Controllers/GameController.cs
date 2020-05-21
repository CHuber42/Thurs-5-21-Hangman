using System;
using Microsoft.AspNetCore.Mvc;
using Game.Models;
using System.Collections.Generic;

namespace Hangman.Controllers
{
  public class GameController : Controller
  {
    [HttpGet("/game")]
    public ActionResult Index()
    {
      List<GameClass> allGames = GameClass.GetAll();
      return View("Index", allGames);
    }

    [HttpGet("/game/new")]
    public ActionResult New()
    {
      GameClass newGame = new GameClass();
      return RedirectToAction("Index");
    }

    [HttpGet("/game/{id}")]
    public ActionResult Show(int id)
    {
      GameClass selectedGame = GameClass.Find(id);
      return View("Show", selectedGame);
    }

    [HttpPost("/game/{id}/letter/update")]
    public ActionResult Update(string guess, int gameid)
    {
      char newGuess = guess[0];
      bool resultFound = false;
      GameClass selectedGame = GameClass.Find(gameid);
      foreach(Letter candidate in selectedGame.Letters)
      {
        if (newGuess == candidate.LetterOfWord)
        {
          candidate.Visible = true;
          resultFound = true;
        }
      }
      if (!resultFound)
      {
        selectedGame.FailsRemaining -= 1;
      }
      return RedirectToAction("Show", gameid);
    }

  }
}