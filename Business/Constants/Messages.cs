using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string AuthorizationDenied ="Yetkiniz yok";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Basarili giris";
        public static string UserAlreadyExists="Kullanıcı zaten var";
        public static string AccessTokenCreated="Token olusturuldu";

        public static string UserRegistered = "";
        public static string UserNotFound = "Kullanıcı bulunamadı";
    }
}
