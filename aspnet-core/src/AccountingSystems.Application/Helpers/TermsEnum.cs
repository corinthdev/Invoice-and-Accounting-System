using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystems.Helpers
{
    public enum TermsEnum
    {
        // COD
        [Display(Name = "COD")]
        CashOnDelivery = 0,
        // 7D
        [Display(Name = "7D")]
        SevenDays = 7,
        // 15D
        [Display(Name = "15D")]
        FifthteenDays = 15,
        // 30D
        [Display(Name = "30D")]
        ThirtyDays = 30,

    }
}
