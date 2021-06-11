using System.Collections.Generic;
using Uno.Domain.Entities;

namespace Uno.Domain.Dtos {
  public class MovimentResultDto {
    bool Error { get; set; }
    IList<Card> cards { get; set; } = new List<Card>();
  }
}
