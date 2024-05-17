using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using vsc.Models;

namespace vsc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    
    public IActionResult Akillitelefon()
    {
        var resim1 = new KitapModel{Resimadi ="phone1.png",Bilgi="Nothing Phone (2)",Fiyat="₺39.999,00"};
        var resim2 = new KitapModel{Resimadi ="phone2.png",Bilgi="TECNO Phantom V Flip",Fiyat="₺37.999,00"};
        var resim3 = new KitapModel{Resimadi ="phone3.png",Bilgi="TECNO Pova 5 Pro",Fiyat="₺14.499,00"};
        ViewBag.Resim1 = resim1;
        ViewBag.Resim2 = resim2;
        ViewBag.Resim3 = resim3;
        return View();
    }
    public IActionResult Kampanyalar()
    {
        var resim1 = new KitapModel{Resimadi ="kamp1.png",Bilgi="Nothing Phone (1)",Fiyat="₺18.999,00"};
        var resim2 = new KitapModel{Resimadi ="kamp2.png",Bilgi="Petkit Pura X Akıllı Kedi Tuvaleti",Fiyat="₺16.999,00"};
        var resim3 = new KitapModel{Resimadi ="kamp3.png",Bilgi="Petkit Tüy Toplayıcı Tarak 2 + Petkit \n Tıraş Makinası 2'si 1 Arada",Fiyat="₺999,00"};
        ViewBag.Resim1 = resim1;
        ViewBag.Resim2 = resim2;
        ViewBag.Resim3 = resim3;
        return View();
    }
   
    
    [HttpPost]
    public IActionResult Kaydol(Kullanici model)
    {
         if (!ModelState.IsValid){
            return View(model);
        }
        else
        {
          return RedirectToAction("KaydolSonuc", model);  
        }
    }  
     public IActionResult Kaydol()
    {
        return View();
    }
    public IActionResult KaydolSonuc(Kullanici model)
    {
          return View("KaydolSonuc",model);
    }
    [HttpGet]
    public IActionResult Iletisim()
    {
        return View();
    }
    //veri almak için 1. yol
    [HttpGet]
    public IActionResult VeriAlGet(int okulno,string ad,string soyad,string sinif,int sinav1,int sinav2)
    {
        int ort=(sinav1+sinav2)/2;
    return Content(okulno+"-"+ad+"-"+soyad+"-"+sinif+"ort:"+ort);
    }
    
    //veri alcamk için 2. yol
    
    public IActionResult VeriAlGet()
    {
      string adsoyad=HttpContext.Request.Query["adsoyad"];
      int s1=int.Parse(HttpContext.Request.Query["s1"]); 
      int s2=int.Parse(HttpContext.Request.Query["s2"]);
      double ort=((double) s1+(double) s2)/2;
      return Content(adsoyad+"-"+"ort: "+ort);

    }
    
    public IActionResult VeriAlPost(int Kac)
    {
        @ViewBag.kac=Kac;
        return View();
    }
    public IActionResult VeriAlPostt(int Kac,int Kacar)
    {
        @ViewBag.kac=Kac;
        @ViewBag.kacar=Kacar;
        return View();
    }
    public IActionResult VeriAlPostTablo(int Satir,int Sutun)
    {
        @ViewBag.satir=Satir;
        @ViewBag.sutun=Sutun;
        return View();
    }
    
    [HttpPost]
    public IActionResult Yukle(Ogrenci ogrenci)
    {
        if (ogrenci.Resim == null || ogrenci.Resim.Length == 0)
        return Content("Resim yüklenemedi.");

        var yol=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",ogrenci.Resim.FileName);
        ogrenci.Resim.CopyTo(new FileStream(yol,FileMode.Create));
        return View(ogrenci);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
