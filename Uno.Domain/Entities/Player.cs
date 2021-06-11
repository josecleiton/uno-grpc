using System;
using System.Collections.Generic;

namespace Uno.Domain.Entities {
  public class Player {
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Position { get; set; }
    public IList<Card> Hand { get; set; } = new List<Card>();
  }
}
