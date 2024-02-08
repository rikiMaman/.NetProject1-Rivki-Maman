using Subscriber.core.response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Interfaces.DAL
{
    public interface ICardRepository
    {
        public Task<BaseResponse> add(CardTable c);
        public bool IsExistId(int id);
        Task<BaseResponseGeneral<GetCardById>> getCard(int id);


    }
}
