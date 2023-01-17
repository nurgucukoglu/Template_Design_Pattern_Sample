using System.Text;
using Template_Design_Pattern_Sample.DAL.Entities;

namespace Template_Design_Pattern_Sample.TemplateDesignPattern
{
    public abstract class UserCardTemplate //abst class:newlenmez ve metodun içi de doldurulabilir. interfacelerde metodun içi doldurulmaz. gövdesiz metotlar yazılır.
    {
        //Ana template'in içini burada şekillendiriyoruz.
        //3 tane prop yazdık.
        protected AppUser AppUser { get; set; }
        protected abstract string SetImage(); //aşağıdı kullanabilmek için metot olarak tanımladık.
        protected abstract string SetFooter();

        public string Build() //
        {
            var sb = new StringBuilder();  //sb metinsel ifadeleri birleştirmek için kullanılan sınıf
                                           // Append metodu: verileri string biçimde birleştirir.
            sb.Append("<div class='card'>"); //önce card açtım

            sb.Append(SetImage());

            sb.Append($@"<div class='card-body'>
                            <h5>{AppUser.UserName}</h5>
                            <p>{AppUser.Description}</p>");//Burada kullanıcı bilgileri alanını getirdim. 
                                                           //Sadece herkesin göreceği kısımları html formatında yazdım. Diğerleri duruma göre değişebilir bu yüzden metot şeklinde tanımladım.
                                   //Burada $ kullanımı string için {} ile değişken yazmamızı sağlıyor. @ sembolü kodu alt satıra geçirerek yazmayı sağlıyor.

            sb.Append(SetFooter()); //butonları footer içinde tanımlamıştım.

            sb.Append("</div>"); //yukarıdaki divleri kapattık
            sb.Append("</div>");

            return sb.ToString();
        }

        public void SetUser(AppUser appUser)  //kullanıcıyı karşılaşayabilmesi için kullanıyoruz
        {
            AppUser = appUser;
        }
    }

    ////Bu template aslında ortak bir ana sınıf iskelet yapı kuruluyor. Bu alt sınıflara miras verilerek alt sınıflar hem buradan ortak özellikleri kendileirne direk alıyor. Aynı zamanda set Metodları ile kendilerine göre o iskelette bulunan alanları küçük farklılıklar ile kendine göre özelleştirebiliyor.
}
