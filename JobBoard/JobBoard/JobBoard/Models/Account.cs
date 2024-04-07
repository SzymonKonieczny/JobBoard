using System.ComponentModel.DataAnnotations;

namespace JobBoard.Models
{
    enum AccountType
    {
        Employer,
        Employee
    }
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string PasswordHashed { get; set; }
        AccountType Type { get; set; }
    }
}
