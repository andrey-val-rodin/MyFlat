using MyFlat.Dto;
using System.Collections.Generic;

namespace MyFlat.Dto
{
    public class AuthorizationDto
    {
        public bool Success { get; set; }
        public List<AuthorizationDataDto> Data { get; set; }
    }
}
