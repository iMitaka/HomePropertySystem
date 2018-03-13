using HomePropertySystem.Models.EntityHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : BaseUserEntity
{
    public ApplicationUser()
    {

    }

    public override string UserName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public override string Email { get; set; }

    public string Avatar { get; set; }
}