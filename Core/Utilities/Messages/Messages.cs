using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class Messages
    {
        public static string StarbucksCustomerAdded = "Starbucks müşterisi başarıyla eklendi";
        public static string StarbucksCustomerNotAdded = "Starbucks müşterisi database'de zaten mevcut. Ekleme yapılmadı";

        public static string PortalCustomerAdded = "Portal müşterisi başarıyla eklendi";
        public static string PortalCustomerNotAdded = "Portal müşterisi database'de zaten mevcut. Ekleme yapılmadı";

        public static string MernisValidationFailed = "Eklemeye çalıştığınız müşterinin bilgileri Mernis ile uyuşmamaktadır.";
    }
}
