using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter
{
	public class NormalService : Normal.NormalBase
	{
		private readonly ILogger<NormalService> _logger;
		public NormalService(ILogger<NormalService> logger)
		{
			_logger = logger;
		}

		public override Task<Actors> GetActors(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
			return Task.FromResult(new Actors
			{
				Actor = "Connell",
				Actress = "Marian"
			});
		}
	}
}
