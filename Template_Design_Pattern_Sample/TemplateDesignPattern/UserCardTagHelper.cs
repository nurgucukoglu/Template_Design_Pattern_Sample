using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Template_Design_Pattern_Sample.DAL.Entities;

namespace Template_Design_Pattern_Sample.TemplateDesignPattern
{
    public class UserCardTagHelper : TagHelper   //Sistemin tasarımı olan kullanıcının sisteme giriş yapıp yapmamasına göre göstereceği template sayfaların yönetimini burada yazdık.
    {
       
        private readonly IHttpContextAccessor _httpContextAccessor;  //Bu user işlemlerini getirebilmek için kullanacağım interace'dir
                                                                     //Burada httpContextAccessor giriş yapan kullanıcının bilgilerini tutuyor. 
                                                                     //bunun sayesinde taghelper içine user ataması yapıp onu view.de çağırıcaz.
        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AppUser AppUser { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) //Process metodunu kendi istediğim yapıda kullanıcam override
        {
            UserCardTemplate userCardTemplate;   //bu UserCardTemplate'in içi başka şekilde dolacak newlemedim o yüzden

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) //eğer bu kullanıcı sisteme authentice olduysa User Card Template Gold'u alacak. Yani Gold'u gösterecek
            {                
                userCardTemplate = new GoldUserCardTemplate();
            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();    //eğer kullanıcı sisteme giriş yapmamışsa DdefaultCard'ı görür.

            }
            userCardTemplate.SetUser(AppUser);

            output.Content.SetHtmlContent(userCardTemplate.Build());//veritabanı ile ilgili işlemi yapı içerisine çeker
            //Böylece Build'i çağırarak tüm oluşturduğum metodları kullandım
        }
    }
}
