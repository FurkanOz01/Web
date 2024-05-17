using System.ComponentModel.DataAnnotations;
public class Kullanici{
   [Display(Name="Kullaniciadi")]
  [Required(ErrorMessage="{0} alanı doldur")]
  [StringLength(20, MinimumLength=3, ErrorMessage="{0} {2}-{1} karakter olmalı")]
  [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage ="harf ve rakamlardan oluşmalı")]//a-z küçük a ile z arasındaki  harflere izin verir. A-Z büyük A ile Z arasındaki  harflere izin verir. 0-9 0ile 9 arasındaki sayılara izin verir.
  public string? KullaniciAdi{get;set;}

  [Display(Name ="Sifre")]
  [Required(ErrorMessage ="{0} giriniz")]
  [StringLength(10, MinimumLength=5, ErrorMessage="{0} {2}-{1} karakter olmalı")]
  [DataType(DataType.Password)]//şifreyi yıldızlı yazar
  public string? Sifre{get;set;}

[Display(Name ="Sifre (Tekrar)")]
  [Required(ErrorMessage ="{0} giriniz")]
  [Compare("Sifre", ErrorMessage ="Sifreler aynı olmalı")]
  [DataType(DataType.Password)]//şifreyi yıldızlı yazar
  public string? SifreTekrar{get;set;}

  [Display(Name="E-posta Adresi")]
  [EmailAddress]//eposta olması gerektiğini bu kodu yazarak belirtiyoruz.
  public string? Eposta{get;set;}

  [Display(Name="Doğum Tarihi")]
  [DataType(DataType.Date)]// tarih girilmesi kontrolü
  public DateTime? DogumTarihi{get;set;}
  
}