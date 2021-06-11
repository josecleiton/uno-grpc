using System;
using System.Collections.Generic;
using System.Linq;

namespace Uno.Domain.Entities {
  public class RoomService {
    // RoomStatus Status { get; set; }
    private readonly LinkedList<Player> _players;
    private readonly List<Card> _deck;
    private readonly Stack<Card> _draw;
    // TODO: fullfil deck
    private static readonly List<Card> deck = new List<Card>();

    public RoomService() {
      var rand = new Random();

      _players = new LinkedList<Player>();
      _deck = RoomService.deck.OrderBy(x => rand.Next()).ToList();
    }

    public Player AddPlayer(Guid playerId) {
      if (_players.Count * Constants.HandSize > _deck.Count) {
        throw new Exception("Room full");
      }

      return new Player {
        Id = playerId,
        Position = _players.Count,
        Hand = _deck.GetRange(_players.Count, Constants.HandSize)
      };
    }

    public IList<Card> Draw(Guid playerId) {
      var player = Validate(playerId);
      player.Hand.Add(_draw.Pop());

      return player.Hand.ToList();
    }

    private Player Validate(Guid playerId) {
      return _players.First.Value.Id == playerId ? _players.First.Value : throw new Exception("dosakd");
    }
  }
}
