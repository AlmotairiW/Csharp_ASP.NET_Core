using System.ComponentModel.DataAnnotations;

namespace DojoSurveyModel.Models
{
    public class Survey
    {
        public string Name {set; get;}
        public string Location {set; get;}
        public string FavLang {get; set;}
        public string Comment {get; set;}
    }
}