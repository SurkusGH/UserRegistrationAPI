using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationAPI.Data.Data
{
    public class User : IdentityUser
    {

        [ForeignKey(nameof(DataSheet))]
        public string DataSheetId { get; set; }
        public DataSheet DataSheet { get; set; }

    }
}
