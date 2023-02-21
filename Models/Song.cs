using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgift4.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // Foreign Key
        public int ArtistID { get; set; }
        [ForeignKey("ArtistID")]
        public virtual Artist Artist { get; set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        public string Title { get; set; }

        public int Length { get; set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        public string Category { get; set; }

        // Foreign key 
        public int cd_id { get; set; }
        [ForeignKey("cd_id")]
        public virtual CD CD { get; set; }
    }
}
