using System.ComponentModel;

namespace DotNetCoreSqlDb.Models
{
    public class BBResponse
    {
        public int ID { get; set; }
        public string? Content { get; set; }

        [DisplayName("作成日時")]
        public DateTime PostDate { get; set; }
    }
}
