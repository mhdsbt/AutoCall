using Application.Interfaces;
using Domain.Entities;
using Domain.Enum.AutoCallRequest;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
	public class CreateAutoCallCommand : IRequest<int>
	{
		public string TrackId { get; set; }
		public string PhoneNumber { get; set; }
		public string Description { get; set; }
		public AutoCallRequestStatus AutoCallRequestStatus { get; set; }
		public class CreateProductCommandHandler : IRequestHandler<CreateAutoCallCommand, int>
		{
			private readonly IApplicationDbContext _context;
			public CreateProductCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}
			public async Task<int> Handle(CreateAutoCallCommand command, CancellationToken cancellationToken)
			{
				var autoCall = new AutoCallRequest();

				autoCall.PhoneNumber = command.PhoneNumber;
				autoCall.TrackId = command.TrackId;
				autoCall.GroupId = Guid.NewGuid();
				autoCall.Status = command.AutoCallRequestStatus;
				_context.AutoCallRequest.Add(autoCall);

				cancellationToken.ThrowIfCancellationRequested();
				await _context.SaveChangesAsync();

				return autoCall.Id;
			}
		}
	}
}