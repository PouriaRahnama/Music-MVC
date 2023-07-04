using Music.Data;
using Music.Web.UnitOfWork;
using Music.Web.Utilities.Contracts;
using Music.Web.Utilities.convertor;
using Music.Web.ViewModels;
using Music.Web.ViewModels.Account;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Music.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWork _UnitOfWork;
        private IEmailSender emailSender;

        public AccountController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            this._UnitOfWork = unitOfWork;
            this.emailSender = emailSender;
        }



        [HttpGet]
        [Route("register", Name = "GetRegister")]
        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [Route("register", Name = "PostRegister")]
        public ActionResult Register(RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                if (!_UnitOfWork.UserService.IsExistUserByUserName(registerUser.UserName))
                {
                    if (registerUser.Password == registerUser.RePassword)
                    {
                        var user = new User()
                        {
                            UserName = registerUser.UserName,
                            Email = registerUser.Email,
                            Password = registerUser.Password,
                            ActiveCode = Guid.NewGuid().ToString("N"),
                            IsDelete = false
                        };
                        _UnitOfWork.UserService.CreateUser(user);
                        _UnitOfWork.save();
                        //Email
                        var body = RazorConvertors.RenderPartialViewToString("EmailSender", "ActivateEmail", user);
                        emailSender.send(registerUser.Email, "فعال سازی حساب کاربری", body);
                        TempData["SendEmailTo"] = "پیامی به ایمیل وارد شده ارسال شد لطفا برای فعالسازی حساب روی لینک داخل پیام کلیک کنید! با تشکر پوریا رهنما";
                        return RedirectToRoute("GetLogin");
                    }
                    ModelState.AddModelError("RePassword", "مغایرت");
                    return View(registerUser);
                }
                ModelState.AddModelError("UserName", "کاربر وجود دارد");
                return View(registerUser);
            }
            return View(registerUser);
        }



        [Route("activate/{id}")]
        public ActionResult activeUser(string id)
        {
            var user = _UnitOfWork.UserService.GetUserByActiveCode(id);
            if (user != null && !user.IsActive)
            {
                user.IsActive = true;
                user.ActiveCode = Guid.NewGuid().ToString("N");
                _UnitOfWork.UserService.UpdateUser(user);
                _UnitOfWork.save();
                TempData["SuccessActivate"] = "حساب شما با موفقیت تایید شد";
                return RedirectToRoute("GetLogin");
            }
            TempData["ErrorActivate"] = "حساب شما با موفقیت تایید نشد";
            return RedirectToRoute("GetLogin");
        }



        [HttpGet]
        [Route("login", Name = "GetLogin")]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost, ValidateAntiForgeryToken]
        [Route("login", Name = "PostLogin")]
        public ActionResult Login(UserLoginViewmodel userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = _UnitOfWork.UserService.GetUserByEmail(userLogin.Email);
                if (user != null)
                {
                    if (user.Password == userLogin.Password)
                    {
                        FormsAuthentication.SetAuthCookie(userLogin.Email, userLogin.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("UserName", "نام کاربری یا کلمه عبور اشتباه است! ");
                    return View(userLogin);
                }
                ModelState.AddModelError("Email", "Not Found");
                return View(userLogin);
            }
            return View(userLogin);
        }



        [Route("Sign-Out" , Name =("SignOut"))]
        public ActionResult Out()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("GetLogin");
        }


    }
}