using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscriber.core.DTO;
using Subscriber.core.Interfaces.BL;
using Subscriber.core.response;
using Subscriber.Data.Entities;

namespace WeightWatchers.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        // POST: SubscriberController/Create
        [HttpPost]
        public async Task<BaseResponse> PostSubscriber(SubscriberDTO s )
        {
            //Task <BaseResponse> r= _subscriberService.add()
            return await _subscriberService.add(s);

        }
        [HttpPost]
        [Route("login")]
        public async Task<BaseResponseGeneral<int>> Login(LoginDTO loginDTO)
        {
            return await _subscriberService.login(loginDTO);
        }





    }
}
