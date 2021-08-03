using System.Collections.Generic;

namespace MyFlat.Dto
{
    public class BalanceDto
    {
        public bool Success { get; set; }
        public List<BalanceChildDto> Data { get; set; }
    }
}
