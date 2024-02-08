using Subscriber.Data.Entities;
using Subscriber.core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscriber.Data;
using Subscriber.core.response;
using Subscriber.core.DTO;

namespace Subscriber.DAL
{
    public class SubscriberRepository : ISubsciberRepository
    {
        readonly WeightWatcherContext _weightWatcherContext;

        public SubscriberRepository(WeightWatcherContext weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }
        public async Task<BaseResponse> add(SubscriberTable s,float height)
        {
            BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();
            _weightWatcherContext.Subscribers.AddAsync(s);
            _weightWatcherContext.SaveChanges();
            var card = new CardTable
            {
                SubscriberId = s.Id,
                OpenDate = DateTime.Now,
                Bmi = 0,
                Height = height,
                Weight = 0,
                UpdateDate = DateTime.Now,
            };
            _weightWatcherContext.Cards.AddAsync(card);
            _weightWatcherContext.SaveChanges();
            response.Succeed = true;
            response.message = "Succeed";
            return response;
        }

        public bool IsExistEmail(string mail)
        {
            if (_weightWatcherContext.Subscribers.Where(t =>t.Email == mail).Any())
                return true;
            return false;
        }
        public bool IsExistId(string id)
        {
            if (_weightWatcherContext.Subscribers.Where(t => t.TZ == id).Any())
                return true;
            return false;
        }


        public bool IsInvalidLogin(LoginDTO l)
        {
            return (_weightWatcherContext.Subscribers.Where(x => x.Email == l.Email && x.Password == l.Password).Any());
        }

        public async Task<BaseResponseGeneral<int>> login(LoginDTO l)
        {
            BaseResponseGeneral<int> r = new BaseResponseGeneral<int>();
            
            

                SubscriberTable s =  _weightWatcherContext.Subscribers.Where(x => x.Email == l.Email && x.Password == l.Password).First();
                r.Data = s.Id;
                r.message = "well done!!!!!!!!!";
           
            return r;
        }
    }
}
