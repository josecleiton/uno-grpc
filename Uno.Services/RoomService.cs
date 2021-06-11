using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Domain.Dtos;
using Uno.Domain.Enums;
using Uno.Services;

namespace Uno.Domain.Entities {
  public class RoomService {
    private static readonly List<Card> deck = new List<Card>();
    private readonly GameStateMachine _gameStateMachine;
    private readonly Card[] _deck;
    private readonly LinkedList<Player> _players = new LinkedList<Player>();
    private readonly Stack<Card> _draw = new Stack<Card>();
    private Orientation _orientation = Constants.StartOrientation;
    private LinkedListNode<Player>? _currentPlayer;
    private ShouldDrawDto? shouldDraw;
    // TODO: fullfil deck

    public RoomService(GameStateMachine gameState) {
      var rand = new Random();

      _gameStateMachine = gameState;
      _deck = RoomService.deck.OrderBy(x => rand.Next()).ToArray();
    }

    public Player AddPlayer(Guid playerId) {
      var cardIdx = _players.Count * Constants.HandSize;
      if (cardIdx > _deck.Count()) {
        throw new Exception("Room full");
      }

      _players.AddLast(new Player {
        Id = playerId,
        Position = _players.Count,
        Hand = _deck.Skip(cardIdx).Take(Constants.HandSize).ToList(),
      });

      return _players.Last!.Value;
    }

    public IList<Card> Draw(Guid playerId) {
      var player = Validate(playerId);
      if (_draw.Count == 0) {
        throw new Exception("Draw is empty");
      }

      player.Hand.Add(_draw.Pop());

      return player.Hand.ToList();
    }

    private LinkedListNode<Player> GetFirstPlayer() {
      if (_players.First == null) {
        throw new Exception("No players");
      }

      return _players.First;
    }

    private Player Validate(Guid playerId) {
      var player = GetFirstPlayer().Value;

      return player.Id == playerId ? player : throw new Exception("Player is not allowed to move");
    }

    private Player NextPlayer() {
      if (_currentPlayer == null) {
        _currentPlayer = GetFirstPlayer();
      } else if (_orientation == Orientation.Clockwise) {
        _currentPlayer = _currentPlayer.Next ?? _players.First!;
      } else {
        _currentPlayer = _currentPlayer.Previous ?? _players.Last!;
      }

      return _currentPlayer.Value;
    }
  }
}
