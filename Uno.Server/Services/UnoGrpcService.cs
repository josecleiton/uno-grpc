using Uno;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Uno.Domain.Services;

namespace Uno.Server {
  public class UnoGrpcService : Uno.UnoBase {
    private readonly ILogger<UnoGrpcService> _logger;
    private readonly IUnoService _unoService;
    public UnoGrpcService(ILogger<UnoGrpcService> logger, IUnoService unoService) {
      _logger = logger;
      _unoService = unoService;
    }
  }
}
