using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{  //projedeki tüm metinler, mesajları buradan yazacagız. 
    public static class Messages // static = 1 tane clasdır newlenmesi yoktur.
    {
        public static string ProductAdded = "Ürün Eklendi";  //public olan degişken isimleri PascalCase yazılır.
        public static string ProductNameInvaid = "Ürün ismi gecersiz.";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed="ürünler listelendi";
        public static string ProductCountOfCategoryError="bir kategoride 15 den fazla ürün olamaz.";
        public static string CategoryLimitExceded="bir ürünün category sayisi 15 i gecemez.";
        public static string AuthorizationDenied="yetkiniz yok";
        public static string UserRegistered ="kayıt olundu";
        public static string UserNotFound="kullanıcı bulunamadı";
        public static string PasswordError="parola hatası";
        public static string SuccessfulLogin="başarılı giriş";
        public static string UserAlreadyExists="";
        public static string AccessTokenCreated ="token olusturuldu";
    }
}
