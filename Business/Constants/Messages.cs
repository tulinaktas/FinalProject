using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
//magic string
namespace Business.Constants
{
    //newlememek icin static
    public static class Messages
    {
        public static string ProductAdded = "Urun eklendi";
        public static string ProductNameInvalid = "Urun ismi gecersiz";
        public static string MaintenanceTime ="Sistem bakimda" ;
        public static string ProductListed ="Urunler listelendi";
        public static string UnitPriceInvalid = "Hatalı price";
        public static string ProductCountOfCategoryError = "Kategori sayısı asıldı";
        public static string SameNameProductError = "Ayni isimli product eklenemez";
        public static string CategoryLimitExceded="Kategori limiti aşıldı, yeni urun eklenemiyor";
    }
}
