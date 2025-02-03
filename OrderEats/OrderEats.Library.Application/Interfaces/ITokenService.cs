using OrderEats.Library.Models.Entities;
using OrderEats.Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(int IdUser, UserRole role);
    }
}
