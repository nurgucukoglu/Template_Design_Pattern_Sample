using System.Text;

namespace Template_Design_Pattern_Sample.TemplateDesignPattern
{
    public class GoldUserCardTemplate : UserCardTemplate  //authentike olan gold üyeler görecek
    {
        protected override string SetFooter()
        {
            //Authenicate olan kullanıcılarda aşağıda butonlar açılacaktı
            //onların html kodunu yazıp string builder ile birleştiriyoruz

            var sb = new StringBuilder();

            sb.Append("<a href='#' class='card-link'>Profili Gör</a>");

            sb.Append("<a href='#' class='card-link'>Mesaj Gönder</a>");

            return sb.ToString();
        }

        protected override string SetImage()
        {
            return $"<img class='car-img-top' src='{AppUser.Image}' style='width:50px;height:50px;'>";

            //değişen image alanı, parametre geleceği için dolar ekledik başına
            //Bu defa authentica kullanıcının resmi geleceği için AppUser.Image'den gelecek. AppUser'ı zaten UserCardTemplate içerdiği için bu sınıfı oradan miras alması ile kullanabiliyoruz
        }
    }
}
