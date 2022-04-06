using CqrsMediatR.Command;
using CqrsMediatR.Data;
using CqrsMediatR.Model;
using CqrsMediatR.Notifications;
using CqrsMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CqrsMediatR.Controllers
{
    [ApiController]
    [Route("controller")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISampleDataStore _sampleDataStore;

        public WalletController(IMediator mediator, ISampleDataStore sampleDataStore)
        {
            _mediator = mediator;
            _sampleDataStore = sampleDataStore;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]GetWalletReadModelRequest getWalletReadModelRequest)
        {
            var wallets = _mediator.Send(new GetWalletQuery(getWalletReadModelRequest));

            return Ok(wallets);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WalletWriteModel walletWriteModel)
        {
            var addedWallet = _mediator.Send(new AddWalletCommand(walletWriteModel));

            // 이메일 발송등의 이벤트 처리및 WalletReadModels에 추가해서 읽을수 있도록 처리 하는 이벤트를 게시
            await _mediator.Publish(new WalletChangedNotification(walletWriteModel));

            //WalletWriteModels에 해당 데이터가 이벤트 처리를 해서 게시되었다는 표시를 해줌
            await _sampleDataStore.SetPublishedEvent(walletWriteModel, nameof(WalletChangedNotification));

            return StatusCode((int)HttpStatusCode.Created, addedWallet);
        }
    }
}
