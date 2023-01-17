namespace Template_Design_Pattern_Sample.TemplateDesignPattern
{
    public class DefaultUserCardTemplate : UserCardTemplate  //authentike olmayanların göreceği kart
    {
        protected override string SetFooter() //footer görmicek
        {
            return string.Empty;         
        }

        protected override string SetImage()
        {
            return "<img class='car-img-top' src='/images/user.jpg' style='width:50px;height:50px;'>";
        }
    }
}
