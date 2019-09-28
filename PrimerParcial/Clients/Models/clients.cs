using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class clients
    {
       [Key]
       public int FriendID { get; set; }
       [Required]
       [DisplayFormat(DataFormatString ="{0:Nombre Completo}",ApplyFormatInEditMode =true)]
       [Range(5,50)]
       public String Name { get; set; }
       public enum list
        {
            Paulo,
            Pablo,
            Pedro,
            Pepe,
            Paul
        }
       public String email { get; set; }
       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
       public DataType Birthdate { get; set; }
       public list List { get; set; }
     


    }
}