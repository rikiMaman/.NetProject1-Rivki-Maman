using AutoMapper;
using Subscriber.core.DTO;
using Subscriber.core.Interfaces.BL;
using Subscriber.core.Interfaces.DAL;
using Subscriber.core.response;
using Subscriber.Data;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Services_BL
{
    public class SubscriberService : ISubscriberService
    {
        readonly ISubsciberRepository _subsciberRepository;
        readonly IMapper _mapper;

        public SubscriberService(ISubsciberRepository subsciberRepository,IMapper mapper)
        {
            _subsciberRepository = subsciberRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse>   add(SubscriberDTO s)
        {
            BaseResponse response = new BaseResponse();
            if (!_subsciberRepository.IsExistEmail(s.Email))
                _subsciberRepository.add(_mapper.Map<SubscriberTable>(s),s.Height);
            return response;

        }

        //public async Task<BaseResponseGeneral<int>> login(LoginDTO l)
        //{
        //    if (_subsciberRepository.IsInvalidLogin(l))
        //    {

        //        return await _subsciberRepository.login(l);

        //    }
        //    return new BaseResponseGeneral<int>() { message = "bad!!!", Succeed = false };
        //}

        public async Task<BaseResponseGeneral<int>> login(LoginDTO s)
        {
            if (_subsciberRepository.IsInvalidLogin(s))
            {
                return await _subsciberRepository.login(s);
            }
            return new BaseResponseGeneral<int>() { Succeed=false, Data=-1 , message="bad request!!!!!"};
        }
    }
}
