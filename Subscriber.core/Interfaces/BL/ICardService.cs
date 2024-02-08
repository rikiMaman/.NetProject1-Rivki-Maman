using Subscriber.core.response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Interfaces.BL
{
    public interface ICardService
    {
        //Task<BaseResponse> add(CardTable c);
        Task<BaseResponseGeneral<GetCardById>> getCard(int id);

    }
}
