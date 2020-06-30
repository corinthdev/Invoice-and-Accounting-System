using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Branches
{
    public class Branch : EntityDto
    {
        public virtual List<string> Kinds { get; set; }

        public Branch()
        {
            Kinds.Add("Grocery");
            Kinds.Add("Sari-Sari Stores");
        }
    }
}
