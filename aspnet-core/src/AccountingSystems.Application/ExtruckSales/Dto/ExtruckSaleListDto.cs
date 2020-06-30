using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.ExtruckSales.Dto
{
    public class ExtruckSaleListDto : FullAuditedEntity<int>
    {
        public string ExtruckSaleCode { get; set; }

        public string CustomerName { get; set; }

        public string CustomerHouseNumber { get; set; }

        public string CustomerStreet { get; set; }

        public string CustomerBarangay { get; set; }

        public string CustomerMunicipality { get; set; }

        public string CustomerProvince { get; set; }

        public string CustomerAddress
        {
            get
            {
                return CustomerHouseNumber + " " + CustomerStreet + " " + CustomerBarangay + " " + CustomerMunicipality + ", " + CustomerProvince;
            }
        }

        public string SalesmanName { get; set; }

        public DateTime ExtruckSaleDate { get; set; }

        public string CreatorUsername { get; set; }
    }
}
