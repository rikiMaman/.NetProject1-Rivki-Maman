using Subscriber.core.Interfaces.DAL;
using Subscriber.core.response;
using Subscriber.Data;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.DAL
{
    public class CardRepository : ICardRepository
    {
        readonly WeightWatcherContext _weightWatcherContext;

        public CardRepository(WeightWatcherContext weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }
        public async Task<BaseResponse> add(CardTable c)
        {
            BaseResponse baseResponse= new BaseResponse();
            _weightWatcherContext.Cards.Add(c);
            _weightWatcherContext.SaveChanges();
            return baseResponse;
        }
        public bool IsExistId(int id)
        {
            return _weightWatcherContext.Subscribers.Where(x=> x.Id== id).Any();
        }
        public async Task<BaseResponseGeneral<GetCardById>> getCard(int id)
        {
            CardTable c = _weightWatcherContext.Cards.Where(x => x.Id == id).First();
            SubscriberTable s = _weightWatcherContext.Subscribers.Where(x => x.Id == id).First();

            return new BaseResponseGeneral<GetCardById>()
            {
                Data = new GetCardById()
                {
                    FirstName = s.firstName,
                    LastName= s.lastName,
                    Weight = c.Weight,
                    Height= c.Height,
                    BMI =c.Bmi,
                    
                   
                }
            };
         
        }
    }
}

