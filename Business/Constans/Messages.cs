using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string CarListed = "Arabalar listelendi";
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarDailyPriceInvalid = "Ürün fiyatı 0'dan büyük olmalıdır";

        public static string BrandAdded = "Marka  eklendi";
        public static string BrandDelete = "Marka  silindi";
        public static string BrandUpdated = "Marka  güncellendi";
        public static string BrandLenghtInvalid = "Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz";

        
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk  silindi";
        public static string ColorUpdated = "Renk  güncellendi";
        public static string MaintenanceTime= "Sistem bakımda";

        public static string RentalNotReturned = "Araç iade edilmedi";
        public static string RentalCar = "Araç kiralandı";
    }
}
