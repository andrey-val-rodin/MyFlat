using System.Collections.Generic;

namespace MyFlat.Dto
{
    public class AccountDto
    {
        public bool Success { get; set; }
        public List<AccountDataDto> Data { get; set; }
    }
}
