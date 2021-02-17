using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISampleApp
{
    public class InsureMembersModel
    {
        public String  MemberId { get; set; }

        public string MemberName { get; set; }

        public int InsureAmount { get; set; }

        public DateTime InsureDate { get; set; }

        public DateTime InsureCliamDate { get; set; }
    }
}
