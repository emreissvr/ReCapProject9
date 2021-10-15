using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        // Car
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarDeleted = "Araba Silindi";
        public static string CarIsNotAvailable = "Bu araba mevcut değil";
        public static string CarUpdated = "Araba bilgileri güncellendi";

        // Brand
        public static string BrandIsNotInvalid = "Marka geçersiz";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandIsNotAvailable = "Marka mevcut değil";

        // Color
        public static string ColorIsNotInvalid = "Renk geçersiz";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorIsNotAvailable = "Renk mevcut değil";

        // Customer
        public static string CustomerIsNotInvalid = "Müşteri geçersiz";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerIsNotAvailable = "Müşteri mevcut değil";

        // Rental
        public static string CarIsNotReturn = "kiralanan Araç geri iade edilmedi";
        public static string RentalAdded = "Kiralık Araç eklendi";
        public static string RentalDeleted = "Kiralık araç silindi";
        public static string RentalUpdated = "kiralık araç Güncellendi";
        public static string RentalIsNotAvailable = "Kiralık araç mevcut değil";

        // User
        public static string UserIsNotInvalid = "Kullanıcı geçersiz";
        public static string UserAdded = "Kullanıcı  eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserIsNotAvailable = "Kullanıcı mevcut değil";
        public static string AuthorizationDenied = "Yetki engellendi.";
        public static string UserRegistered = "Kullanıcı kayıt edildi";


        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Arabalar listelendi";

        // CarImage
        public static string ImageAddedSuccessfully = "Resim başarıyla eklendi.";
        public static string ImageDeletedSuccessfully = "Resim başarıyla silindi.";
        public static string ImageUpdatedSuccessfully = "Resim başarıyla güncellendi.";
        public static string MaksimumImageLimitReached = "Bir araç için izin verilen en fazla resim sayısına ulaştınız.";
        public static string CheckIfImageLimit = "Daha fazla görsel ekleyemezsiniz.";
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string UserAlreadyExists;
        internal static string SuccessfulLogin;
        internal static string AccessTokenCreated;
    }
}
