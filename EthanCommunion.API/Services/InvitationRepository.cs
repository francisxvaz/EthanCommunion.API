using EthanCommunion.API.Entities;

namespace EthanCommunion.API.Services
{
    public class InvitationRepository : IInvitationRepository
    {
        private StarsContext _starContext;

        public InvitationRepository(StarsContext starsContext)
        {
            _starContext = starsContext;
        }

        public void AcceptDeclineInvitation(int id, bool accept)
        {
            _starContext.Update<Invitation>(new Invitation {
                StarId = id,
                Accepted = accept
            });
        }
    }
}
