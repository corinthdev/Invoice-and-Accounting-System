using AccountingSystems.DebitMemos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.DebitMemo
{
    public class DebitMemoListViewModel
    {
        public IReadOnlyList<DebitMemoListDto> DebitMemos { get; set; }
    }
}
