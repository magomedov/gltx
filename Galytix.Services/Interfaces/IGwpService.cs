using System.Collections.Generic;
using Galytix.Compute;
using Galytix.Data.Models;

namespace Galytix.Services.Interfaces
{
    public interface IGwpService
    {
        List<Peer> GetPeers(string countryCode, string lineOfBusiness, int numberOfPeers);
    }
}