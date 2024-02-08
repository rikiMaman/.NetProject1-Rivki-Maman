using Subscriber.core.DTO;
using Subscriber.core.response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Interfaces.DAL
{
    public interface ISubsciberRepository
    {
        Task<BaseResponse> add(SubscriberTable s,float f);
        bool IsInvalidLogin(LoginDTO l);
        public bool IsExistId(string id);
        public bool IsExistEmail(string mail);
        Task<BaseResponseGeneral<int>> login(LoginDTO l);
    }
}
