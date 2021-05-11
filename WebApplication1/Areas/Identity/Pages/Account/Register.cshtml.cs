using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MimeKit;
using ShoppingCart.Application.Interfaces;
using WebApplication1.Models;
using WebApplication1.Utility;
using static WebApplication1.Utility.Encryption;

namespace WebApplication1.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "TEACHER")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMembersService _membersService;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IMembersService membersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _membersService = membersService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Address { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            /*
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            */
            public string Password { get; set; }
            /*
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            */
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName /*Address= Input.Address*/ };

                string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
                Random random = new Random();
 
                char[] chars = new char[15];
                for (int i = 0; i < 15; i++)
                {
                    chars[i] = validChars[random.Next(0, validChars.Length)];
                }

                string pass = new string(chars);

                Input.Password = pass;
                var result = await _userManager.CreateAsync(user, Input.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "STUDENT");
                    AsymmetricKeys keys = new AsymmetricKeys();
                    keys = Encryption.GenerateAsymmetricKeys();
                    string teacherEmail = User.Identity.Name;
                    _membersService.AddMember(
                       new ShoppingCart.Application.ViewModels.MemberViewModel()
                       {
                           Email = Input.Email,
                           FirstName = Input.FirstName,
                           LastName = Input.LastName,
                           PublicKey = keys.PublicKey,
                           PrivateKey = keys.PrivateKey,
                           TeacherEmail = teacherEmail
                       }
                   );

                    _logger.LogInformation("User created a new account with password.");

                    try{
                        MailMessage message = new MailMessage("michaelmcast@outlook.com", Input.Email);
                        message.Subject = "User Registered";
                        message.Body = "--- Welcome User ----\n " +
                            "Please find your account details below \n" +
                            "Username: " + Input.Email + "\n" +
                            "Password : " + Input.Password;
                        SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                        System.Net.NetworkCredential basicCredential1 = new
                        System.Net.NetworkCredential("michaelmcast@outlook.com", "mcast262199");
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = basicCredential1;
                        client.Send(message);
                    }catch (Exception ex){
                        throw ex;
                    }

                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
