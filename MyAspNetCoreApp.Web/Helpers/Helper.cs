namespace MyAspNetCoreApp.Web.Helpers
{
    public class Helper : IHelper
    {
        private bool _isConfiguration;

        public Helper(bool isConfiguration)
        {
            _isConfiguration = isConfiguration;     
        }
        public string ConvertCase(string text)
        {
            if (_isConfiguration)
            {
                return text.ToUpper();
            }

            return text.ToLower();
        }
    }
}
