using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreSqlDb.Models
{
    public class BBThread
    {
        public int ID { get; set; }
        public string? Title { get; set; }

        [DisplayName("作成日時")]
        public DateTime PostDate { get; set; }
    }
}
