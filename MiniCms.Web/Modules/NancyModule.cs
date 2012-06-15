using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using Nancy;

namespace MiniCms.Web.Modules
{
    public class NancyModule : Nancy.NancyModule
    {
        private readonly INewsletterSubscriberRepository _newsletterSubscriberRepository;
        public NancyModule(INewsletterSubscriberRepository newsletterSubscriberRepository) : base("/nancy")
        {
            _newsletterSubscriberRepository = newsletterSubscriberRepository;


            Get["/newsletter/signup"] = _ => "ddddd";

            Get["/"] = _ => "Hello";

            string test = "/test";

            Get["/test"] = _ => "test";

            Get["/test/a/a"] = _ => "testa";

            //{
            //                                                   _newsletterSubscriberRepository.Save(
            //                                                       new NewsletterSubscriber
            //                                                           {
            //                                                               Email = (string)Request.Query.email.Value,
            //                                                               Name = (string)Request.Query.name.Value
            //                                                           });
            //                                                   return "Success";
            //                                               };
        }
    }
}