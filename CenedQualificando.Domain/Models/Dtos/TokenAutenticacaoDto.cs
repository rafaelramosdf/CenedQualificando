using CenedQualificando.Domain.Models.Base;
using System;

namespace CenedQualificando.Domain.Models.Dtos
{
    public class TokenAutenticacaoDto : IDto
    {
        public string Token { get; set; }
        public DateTime ExpiraEm { get; set; }
    }
}
