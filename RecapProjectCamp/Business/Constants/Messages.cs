using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    //static yaapıyoruz
    //static newlenmez
    public static class Messages
    {
        public static string RentalNotAvailable = "Rental mevcut değil!";
        public static string CarsListed = "\nTüm arabalar listelendi\n";
        public static string CarAdded = "\nAraba eklendi\n";
        public static string CarDeleted = "\nAraba silindi\n";
        public static string CarUpdated = "\nAraba bilgileri güncellendi\n";
        public static string CarDescriptionInvalid = "\nEklenen araba açıklaması en az 2 harften oluşmalıdır.";
        public static string CarDailyPriceInvalid = "\nAraba günlük fiyatı 0 dan büyük olmalıdır.\n";
        public static string CarUndelivered = "\nAraba teslim edilmemiştir, kiralanamaz.\n";
        public static string CarRented = "\nAraba kiralandı.\n";
        public static string UserAdded = "\nKullanıcı eklendi.\n";
        public static string CustomerAdded = "\nMüşteri eklendi.\n";
        public static string ImageAddFailed = "Limite ulaşıldığından resim eklenemedi";
        public static string AuthorizationDenied = "Yetki reddedildi!";
        public static string CustomerDetailSuccess = "Müşteri detayları getirildi!";
        public static string RentalDetailSuccess = "Kiralık detayları getirildi!";
        public static string FailedCarImageAdd = "Resim eklenemedi!";
        public static string AddedCarImage = "Resim eklendi!";
        public static string DeletedCarImage = "Resim silindi!";
        public static string CarsFiltered = "Araçlar filtrelendi!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Şifre yanlış!";
        public static string SuccessfulLogin = "Başarılı giriş!";
        public static string AccessTokenCreated = "Access Token oluşturuldu!";
        public static string creditCardAdded = "Kredi kartı eklendi!";
        public static string creditCardDeleted = "Kredi kartı silindi!";
        public static string RentalUndeliveredCar = "Araç kiralanamaz!";
        public static string FindeksNotFound = "Findeks notu bulunamadı!";
        public static string FindeksAdded = "Findeks eklendi!";
        public static string FindeksUpdated = "Findeks güncellendi!";
        public static string FindeksDeleted = "Findeks silindi!";
        public static string FindeksNotEnoughForCar = "Findeks puanı kiralama yeterli değil!";
        public static string RentalAdded = "Araç kiralandı!";
        public static string PaymentFailed = "Ödeme başarısız!";
        public static string PaymentSuccessful = "Ödeme başarılı!";
        public static string OperationClaimAdded = "Rol eklendi!";
        public static string OperationClaimUpdated = "Rol güncellendi!";
        public static string OperationClaimDeleted = "Rol silindi!";
        public static string UserOperationClaimAdded = "Rol üyeye eklendi!";
        public static string UserOperationClaimUpdated = "Üyenin rolü güncellendi!";
        public static string UserOperationClaimDeleted = "Üyenin rolü silindi!";
    }
}
