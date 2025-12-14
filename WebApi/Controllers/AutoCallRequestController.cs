using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AutoCallRequestController : BaseApiController
    {
        private readonly IMessagePublisher _MessagePublisher;

        public AutoCallRequestController(IMessagePublisher iMessagePublisher)
        {
            _MessagePublisher = iMessagePublisher;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAutoCallCommand command)
        {
            await Mediator.Send(command);

            var payLoad = new
            {
                PhoneNumber = command.PhoneNumber,
                AutoCallRequestStatus = (int)command.AutoCallRequestStatus
            };

            await _MessagePublisher.PublishAsync("AutoCallRequest", payLoad);

            return Ok();
        }
    }
}