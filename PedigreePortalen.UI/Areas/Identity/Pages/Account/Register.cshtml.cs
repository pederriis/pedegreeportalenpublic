using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
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
using PedigreePortalen.Shared.UserMicroserviceDto.Commands;
using PedigreePortalen.UI.Models;
using static PedigreePortalen.UI.Mapper.UserMicroServiceMapper.UserMapper;

namespace PedigreePortalen.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly HttpClient _httpClient;


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            HttpClient httpClient)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _httpClient = httpClient;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            //Domain User
            public Guid UserId { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string PhoneNo { get; set; }

            public string Street { get; set; }

            public string City { get; set; }

            public string Zipcode { get; set; }

            public string ProfileText { get; set; }
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
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var domainUser = new UserViewModel.UserCreate 
                { 
                    UserId = Input.UserId,
                    LoginUserId = user.Id,
                    FirstName = Input.FirstName, 
                    LastName = Input.LastName, 
                    Email = Input.Email, 
                    PhoneNo = Input.PhoneNo, 
                    Street = Input.Street, 
                    City = Input.City, 
                    Zipcode = Input.Zipcode, 
                    ProfileText = Input.ProfileText 
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                var resultDomainUser = await CreateDomainUser(domainUser);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task<UserViewModel.UserCreate> CreateDomainUser([Bind("UserId,LoginUserId,FirstName,LastName,Email,PhoneNo,Street,City,Zipcode,ProfileText")] UserViewModel.UserCreate user)
        {
            UserCommandsDto.V1.CreateUser userDto = UserCreateMapper.Map(user);

            if (ModelState.IsValid)
            {
                    userDto.UserId = Guid.NewGuid();
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync
                        ($"gateway/User/CreateUser?UserId={userDto.UserId}&LoginUserId={userDto.LoginUserId}&FirstName={userDto.FirstName}&LastName={userDto.LastName}&Email={userDto.Email}&PhoneNo={userDto.PhoneNo}&Street={userDto.Street}&City={userDto.City}&Zipcode={userDto.Zipcode}&ProfileText={userDto.ProfileText}", userDto);
                    response.EnsureSuccessStatusCode();

                    //if (response.IsSuccessStatusCode)
            }
            return user;
        }
    }
}
