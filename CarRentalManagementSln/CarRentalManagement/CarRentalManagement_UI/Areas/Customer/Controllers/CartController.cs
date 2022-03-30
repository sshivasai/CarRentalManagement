using CarRentalManagement_DAL.Dto;
using CarRentalManagement_DAL.Repository.IRepository;
using CarRentalManagement_DAL.ViewModels;
using CarRentalManagement_UI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;

namespace CarRentalManagement_UI.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        //[AllowAnonymous]

        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public int OrderTotal { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                ListItem = _unitOfWork.ShoppingCart.GetAll(u=>u.ApplicationUserId == claim.Value,
                includeProperties: "Car"),
                OrderHeader = new()


            };
            foreach(var cart in ShoppingCartVM.ListItem)
            {
                DateTime pickupDate = cart.PickupDate.Date;
                DateTime returnDate = cart.ReturnDate.Date;
                TimeSpan difference = returnDate.Subtract(pickupDate);
                int days = ((int)difference.TotalDays) + 1;
                cart.Price = GetPriceBasedOnDays(cart.PickupDate, cart.ReturnDate, (double)cart.Car.PricePerDay,
                    (double)cart.Car.PricePerWeek, (double)cart.Car.PricePerMonth);
                cart.Days = days;
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price) * days;
            }

           


            return View(ShoppingCartVM);
        }
        public IActionResult Summary()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                ListItem = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "Car"),
                OrderHeader = new()
                


            };
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(U=>U.Id==claim.Value);
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
           



            foreach (var cart in ShoppingCartVM.ListItem)
            {
                DateTime pickupDate = cart.PickupDate.Date;
                DateTime returnDate = cart.ReturnDate.Date;
                TimeSpan difference = returnDate.Subtract(pickupDate);
                int days = ((int)difference.TotalDays) + 1;
                cart.Price = GetPriceBasedOnDays(cart.PickupDate, cart.ReturnDate, (double)cart.Car.PricePerDay,
                    (double)cart.Car.PricePerWeek, (double)cart.Car.PricePerMonth);
                cart.Days = days;
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price) * days;
            }




            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ActionName("Summary")]
        [ValidateAntiForgeryToken]
        public IActionResult SummaryPOST()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM.ListItem = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "Car");

            ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
            ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = claim.Value;

            foreach (var cart in ShoppingCartVM.ListItem)
            {
                DateTime pickupDate = cart.PickupDate.Date;
                DateTime returnDate = cart.ReturnDate.Date;
                TimeSpan difference = returnDate.Subtract(pickupDate);
                int days = ((int)difference.TotalDays) + 1;
                cart.Price = GetPriceBasedOnDays(cart.PickupDate, cart.ReturnDate, (double)cart.Car.PricePerDay,
                    (double)cart.Car.PricePerWeek, (double)cart.Car.PricePerMonth);
                cart.Days = days;
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price) * days;
            }

            _unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
            _unitOfWork.Save();


            foreach (var cart in ShoppingCartVM.ListItem)
            {
                OrderDetail orderDetail = new()
                {
                    CarId = cart.CarId,
                    OrderId = ShoppingCartVM.OrderHeader.Id,
                    Price = cart.Price,
                    PickUpDate = cart.PickupDate,
                    ReturnDate = cart.ReturnDate,
                    Days = cart.Days

                };
                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();

            }

            //stripe settings
            var domain = "https://localhost:44374/";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}",
                CancelUrl = domain + $"customer/cart/index",
            };


            foreach (var item in ShoppingCartVM.ListItem)
            {

                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100),//20.00 -> 2000
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Car.Name
                        },

                    },
                    Quantity = item.Days,
                };
                options.LineItems.Add(sessionLineItem);

            }
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            _unitOfWork.OrderHeader.UpdateStripePaymentID(ShoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            return new StatusCodeResult(303);
            //_unitOfWork.ShoppingCart.RemoveRange(ShoppingCartVM.ListItem);
            //_unitOfWork.Save();
            //return RedirectToAction("Index", "Home");
        }
        public IActionResult OrderConfirmation(int id)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == id, includeProperties: "ApplicationUser");
           
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);
                //check the stripe status
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                    _unitOfWork.Save();
                }
            else
            {
                _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusPending, SD.PaymentStatusPending);
                _unitOfWork.Save();
            }
            //_emailSender.SendEmailAsync(orderHeader.ApplicationUser.Email, "New Order - Car Rental Management", "<p>New Booking Created</p>");
            List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId ==
            orderHeader.ApplicationUserId).ToList();
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();
            return View(id);
        }
        public IActionResult Remove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u=>u.Id== cartId);
            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }




        private double GetPriceBasedOnDays(DateTime pickupDate,DateTime returnDate, double priceperday, double priceperweek, double pricepermonth)
        {
            pickupDate = pickupDate.Date;
            returnDate = returnDate.Date;
            TimeSpan difference = returnDate.Subtract(pickupDate);
            int days = ((int)difference.TotalDays) + 1;

            if (days <= 7)
            {
                return priceperday;
            }
            else
            {
                if (days <= 15)
                {
                    return priceperweek;
                }
                return pricepermonth;
                }
        }
    }
}
