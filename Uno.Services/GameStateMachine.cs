using System.Collections.Generic;
using Uno.Domain.Dtos;
using Uno.Domain.Entities;

namespace Uno.Services {
  public class GameStateMachine {
    private readonly Stack<Card> _playedCards = new Stack<Card>();
    public GameStateResultDto Execute(Card top, Card playerCard) {
      var result = new GameStateResultDto();

      return result;
    }
  }
}