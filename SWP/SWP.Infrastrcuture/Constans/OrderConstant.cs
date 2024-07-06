using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constans
{
    public static class OrderConstant
    {
        public const string PROCESSING_STATUS = "PROCESSING";
        public const string DELIVERING_STATUS = "DELIVERING";
        public const string DELIVERED_STATUS = "DELIVERED";
        public const string CANCEL_STATUS = "CANCEL";

        public const string PAID_STATUS = "PAID";
        public const string UNPAID_STATUS = "UNPAID";
        public const string REFUNDED_STATUS = "REFUNDED";
        public const string WAITREFUNDED_STATUS = "WAIT REFUNDED";
    }
}
