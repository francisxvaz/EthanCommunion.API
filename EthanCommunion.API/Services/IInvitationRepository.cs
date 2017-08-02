using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthanCommunion.API.Services
{
    public interface IInvitationRepository
    {
        void AcceptDeclineInvitation(int id, bool accept);
    }
}
