using HotelReservation.Business.Abstract;
using HotelReservation.Business.CrossCuttingConcern.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IAboutService _aboutService;
        readonly ICommentService _commentService;
        readonly IContactService _contactService;
        readonly IGuideService _guideService;
        readonly IHotelService _hotelService;
        readonly IOurServiceService _ourService;
        readonly IPictureService _pictureService;
        readonly IPricingService _pricingService;
        readonly ISocialMediaService _socialMediaService;

        public HomeController(ILogger<HomeController> logger, IAboutService aboutService, ICommentService commentService, IContactService contactService, IGuideService guideService, IHotelService hotelService, IOurServiceService ourService, IPictureService pictureService, IPricingService pricingService, ISocialMediaService socialMediaService)
        {
            _logger = logger;
            _aboutService = aboutService;
            _commentService = commentService;
            _contactService = contactService;
            _guideService = guideService;
            _hotelService = hotelService;
            _ourService = ourService;
            _pictureService = pictureService;
            _pricingService = pricingService;
            _socialMediaService = socialMediaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("sitemap.xml")]
        public async Task<IActionResult> OnGet()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version='1.0' encoding='UTF-8' ?><urlset xmlns = 'http://www.sitemaps.org/schemas/sitemap/0.9'>");

            var about = await _aboutService.GetAll();
            foreach (var item in about)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.Description + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var socialMedia = await _socialMediaService.GetAll();
            foreach (var item in socialMedia)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.Name + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var guide = await _guideService.GetAll();
            foreach (var item in guide)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.NameSurname + item.Expertise + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var contact = await _contactService.GetAll();
            foreach (var item in contact)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.City + item.Province + item.Country + item.EmailAddress + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var hotel = await _hotelService.GetAll();
            foreach (var item in hotel)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.Name + item.Title + item.Description + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var service = await _ourService.GetAll();
            foreach (var item in service)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.ServiceType + item.Price.ToString() + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var pricing = await _pricingService.GetAll();
            foreach (var item in pricing)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.Accomodation + item.Price.ToString() + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var picture = await _pictureService.GetAllPictures();
            foreach (var item in picture)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.Title + item.ImageUrl + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }

            var comment = await _commentService.GetAllComments();
            foreach (var item in comment)
            {
                string mDate = item.CreatedDate.ToString("yyyy-MM-dd");
                sb.Append("<url><loc>" + item.Subject + item.Text + "</loc><lastmod>" + mDate + "</lastmod><priority> 0.8</priority></url>");
            }
            sb.Append("</urlset>");

            return new ContentResult
            {
                ContentType = "application/xml",
                Content = sb.ToString(),
                StatusCode = 200
            };
        }

        [Route("rss.xml")]
        public async Task<IActionResult> Rss()
        {
            Response.Clear();
            Response.ContentType = "text/xml";
            XmlTextWriter rssWriter = new XmlTextWriter(Response.BodyWriter.AsStream(true), Encoding.UTF8);
            rssWriter.WriteStartDocument();
            rssWriter.WriteStartElement("rss");
            rssWriter.WriteAttributeString("version", "1.0");
            rssWriter.WriteStartElement("channel");
            rssWriter.WriteElementString("title", "myHotel.com RSS Sample");
            rssWriter.WriteElementString("link", "myHotel.com/rss.xml");
            rssWriter.WriteElementString("description", "myHotel.com");
            rssWriter.WriteElementString("copyright", "(c) 2023, myHotel.com");
            rssWriter.WriteElementString("pubDate", "15/03/2023");
            rssWriter.WriteElementString("language", "en-EN");
            rssWriter.WriteElementString("webMaster", "myHotel@gmail.com");

            var about = await _aboutService.GetAll();
            foreach (var x in about)
            {
                rssWriter.WriteStartElement("item");
                rssWriter.WriteElementString("title", "http://localhost:7215/About/" + x.Title);
                rssWriter.WriteElementString("title", "http://localhost:7215/About/" + x.Subtitle);
                rssWriter.WriteElementString("title", "http://localhost:7215/About/" + x.Description);
                rssWriter.WriteElementString("pubDate", x.CreatedDate.ToShortDateString());
                rssWriter.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
                rssWriter.WriteEndElement();
            }

            var socialMedia = await _socialMediaService.GetAll();
            foreach (var x in socialMedia)
            {
                rssWriter.WriteStartElement("item");
                rssWriter.WriteElementString("title", "http://localhost:7215/SocialMedia/" + x.Name);
                rssWriter.WriteElementString("title", "http://localhost:7215/SocialMedia/" + x.Url);
                rssWriter.WriteElementString("pubDate", x.CreatedDate.ToShortDateString());
                rssWriter.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
                rssWriter.WriteEndElement();
            }

            rssWriter.WriteEndDocument();
            rssWriter.Flush();
            rssWriter.Close();
            Response.Body.Close();
            return View();
        }
    }
}